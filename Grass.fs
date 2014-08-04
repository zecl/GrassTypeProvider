module Grass
open System
open System.Collections.Generic

type private token = Tw | TW | Tv | EoF
type private Value = Value of char option * (Value -> Value)
let queue = new System.Collections.Generic.Queue<byte> ()

let list = new List<string>()
let addList x = list.Add x

//let private write =
//  (fun _ (c : char) ->
//  let (|HEIGHT|_|) x = match x with | x when x >= 0x81uy && x <= 0x9Fuy || x >= 0xE0uy -> Some x | _ -> None
//  let (|LOW|_|) x = match x with | x when x >= 0x40uy && x <= 0x7Euy || x >= 0x80uy && x <= 0xFCuy -> Some x | _ -> None
//  match c |> byte with
//   | HEIGHT x when queue.Count = 0 -> x |> queue.Enqueue 
//   | LOW x when queue.Count <> 0 -> [|queue.Dequeue (); x|] |> System.Text.Encoding.GetEncoding(932).GetString |> Console.Write
//   | _ -> Console.Write c ) ()

let private write =
  (fun _ (c : char) ->
  let (|HEIGHT|_|) x = match x with | x when x >= 0x81uy && x <= 0x9Fuy || x >= 0xE0uy -> Some x | _ -> None
  let (|LOW|_|) x = match x with | x when x >= 0x40uy && x <= 0x7Euy || x >= 0x80uy && x <= 0xFCuy -> Some x | _ -> None
  match c |> byte with
   | HEIGHT x when queue.Count = 0 -> x |> queue.Enqueue 
   | LOW x when queue.Count <> 0 -> [|queue.Dequeue (); x|] |> System.Text.Encoding.GetEncoding(932).GetString |> addList
   | _ -> addList (c.ToString()) ) ()
   
let private char' x = Value (Some x, fun y ->
  let True = Value (None, fun x -> Value (None, fun _ -> x))
  let False = Value (None, fun _ -> Value (None, fun y -> y))
  match y with 
   | Value (Some y, _) -> match x,y with | x,y when x = y -> True | _ -> False
   | _ -> raise (new ArgumentException("Char : char以外はだめ")))

let private initStack = [
  Value (None, function
    | Value (Some c, _) as v -> write c; v
    | _ -> raise (new ArgumentException("primitive Out : char以外はだめ")));  
  Value (None, function
    | Value (Some c, _) -> (int c + 1) % 256 |> char |> char'
    | _ -> raise (new ArgumentException("primitive Succ : char以外はだめ"))); 
  char' 'w';
  Value (None, fun x -> try stdin.ToString() |> char |> char' with eof -> x)]  

let private createStack  () = 
  (fun _ -> let stack = ref initStack
            fun x -> match x with 
                      | [] -> !stack 
                      | _  -> stack := x @ !stack; !stack) () 

let rec private analyze i (source:string) = 
  let (|EOF|_|) x = match x with | x when x >= source.Length  -> Some x | _ -> None
  match i with 
   | EOF i -> i, EoF
   | _ -> match source.[i] with
           | 'w'|'ｗ' -> i + 1, Tw
           | 'W'|'Ｗ' -> i + 1, TW
           | 'v'|'ｖ' -> i + 1, Tv
           | _ -> analyze (i + 1) source

let rec private read target (index, token as position) i source = 
  match token,target with 
    | token,target when token = target -> read target (analyze index source) (i + 1) source
    | _ -> position, i

let rec private readBody position body source = 
  let position, f = read TW position 0 source 
  match f with 
   | 0 -> (position, List.rev body) 
   | _ -> let position, a = read Tw position 0 source
          readBody position ((f, a) :: body) source

let rec private app f a stack = 
  match stack with
   | [] -> raise (new ArgumentException("stack"))
   | v::st ->
    match a,f with
     | 1,_ -> let Value = List.nth stack (f - 1) 
              match Value with 
               | Value (c,func) -> func v
     | _,1 -> let arg = List.nth stack (a - 1) 
              let value  =  List.nth stack (f - 1)
              match value with 
               | Value (c,func) -> func arg
     | _   -> st |> app (f - 1) (a - 1)      

let run source = 
  list.Clear()
  queue.Clear()
  let stack = createStack ()
  let rec run (index, token as position) = 
    match token with
      | EoF -> [] |> stack |> app 1 1 |> ignore
      | Tw ->
        let position, argc = read Tw position 0 source
        let position, body = readBody position [] source
        let rec bind n stack arg = 
          let stack = arg :: stack
          match n with
           | 1 -> let rec loop stack body = 
                    match body with
                     | [] -> List.head stack
                     | (f, a) :: [] -> stack |> app f a
                     | (f, a) :: br -> loop ((stack |> app f a) :: stack) br
                  loop stack body
           | _ -> Value (None, bind (n - 1) stack)  
        [Value (None, bind argc (stack[]))] |> stack |> ignore
        run position
      | TW ->
        let position, f = read TW position 0 source
        let position, a = read Tw position 0 source
        [stack [] |> app f a] |> stack |> ignore
        run position
      | Tv -> run (analyze index source)

  let start = 
    let rec loop i = 
      let (index, token) as result = analyze i source
      match token with
       | Tw | EoF -> result 
       | _ -> loop index
    loop 0
  start |> run
  list |> Seq.reduce ((+))
