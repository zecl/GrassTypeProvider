ちょっと草植えときますね型言語Grass型プロバイダー
======================
ちょっと草植えときますね型言語Grassを安全に...。


サンプル
--------
```fsharp:Script.fsx
#r @".\bin\Debug\GrassTypeProvider.dll"
open GrassTypeProvider

type Grass1 = Grass<"wvwwWWwWWWwvWwwwwWWwWWWwWWWWwWWWWWwWWWWWWwWWWWWWWwWwwwwwwwwwwwwWWWwWWWWWwWWWWWWWwWWWWWWWWWwWWWWWWWWWWWWwWWWWWWWWWWWWWWWWWwWWWWWWWWWWWWwWWWWWWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwWwwwwwWWwwwwWWWwwww">
let grass1 = new Grass1()
grass1.Run() // orz
grass1.Value |> printfn "%s" // orz

type Grass2 = Grass<"wvwwWWwWWWwvWwwwwWWwWWWwWWWWwWWWWWwWWWWWWwWWWWWWWwWwwwwwwwwwwwwWWWWwWWWWWWWwWWWWWWWWWWWWWWwWWWWWWWWWWWwwWWWWWWWWWWwwWWWWWWWWWWWWwWWWWWWWWWWwwWWWWWWWWWWwwwwwwWWWWWWWWWWWWWWWwWWWWWWWWWWWWWWWWWWWWWwWWWWWWWWWWWWWWWWWWwwWWWWWWWWWWWWWWWWWwwWWWWWWWWWWWWWWWWWwwwwwWWWWWWWWWWWWWWWWWWWWwwWWWWWWWWWWWWWWWWWWWWWWwWWWWWWWWWWWWWWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwwwwwwwWwwwwwwwwwwWWwwwwwwwWWWwwwwwwwWWWWwWWWWWwwwwwwwwWWWWWWwwwwwwwwwwwwwwwwWWWWWWWwwwwwwwwwwwwwwwwwwwwWWWWWWWWwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwWWWWWWWWWwwwwWWWWWWWWWWwwwwwwwwwwwWWWWWWWWWWWwwwwwwwWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwWWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwwwwww">
let grass2 = new Grass2()
grass2.Run() // Hello, world!
grass2.Value |> printfn "%s" // Hello, world!

type Grass3 = Grass<"wwwwvwvwwWWwvwwWwwvwwwwWWWwwWwwWWWWWWwwwwWwwvwWWwWwwvwWWWwwwwwWwwwwwwWWwWWWwWWWWWWwWWWWWWWWwwwWwwWWWWWWWWWWwWwwwwwWWWWWWWWWWWwwwwwWWWWWWWWWWWWwwwwWWWWWWWWWWWWWwwwWWWWWWWWWWWWWWwwwWWWWWWWWWWWWWWWwWWWWWWWWWWWWWWWWWWwwwWwwwwwwwwwwwwwwWWWWWWWWWWWWWWWWWWWwwwwwwwwWwwWWWWWWWWWWWWWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwwwwwWwwwwwwwwwwwwwwwwwwwwwwwwwwwwwWWwwwwwwwwwwwwwwwwwwwwwwwwはwwwwwWWWWWWWWWWWWWWWwWwwwWWWWわいWWWWWWWwwwWwwWWWWWWWWWWWWwwwwろはwWwwwwwwwWWWWWWWWWWWWWWWWWwwwwすいwwwWwwWWWWWWWWWWWWWWWWWWwwwwwわwwwwWwwWWWWWWWWWWWWWWWWWWWWWろWWWWWWWWWwwwwwwwwwwwWwwWWWWWWWすWWWWWWWWWwwwwwwwwwwwwwWwwwwwwwwwwwwwwwWWWWWWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwWwwwwwwwwwwwwwwWWwwwwwwwwwWWWwwWWWWwwwwwwwwwwwwwwwWWWWWwwWWWWWWwwwwWWWWWWWwwWWWWWWWWwwwwWWWWWWWWWwwWWWWWWWWWWwwwwwwwwwwwwwWWWWWWWWWWWWWWWWWWWWWWWWWWWWwwwwwwwwwwwWwwwWWwwwwwwwwwwwwwwwwwwWWWwwWWWWwwwwwwwwwwwwwwwwwwwwwwwwWWWWWwwWWWWWWwwwwwwwWWWWWWWwwWWWWWWWWwwwwwwWWWWWWWWWwwWWWWWWWWWWwwwwwwWWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwwww">
let grass3 = new Grass3()
grass3.Run() // はいはいわろすわろす\n
grass3.Value |> printfn "%s" // はいはいわろすわろす\n

[<Literal>]
let www4 = """
wvwwWWwWWWwvWwwwwWWwWWWwWWWWwWWWWWw
WWWWWWwWWWWWWWwWwwwwwwwwwwwwWWWWwWW
WWWWWwWWWWWWWWWWWWWWwWWWWWWWWWWWwwW
WWWWWWWWWwwWWWWWWWWWWWWwWWWWWWWWWWw
wWWWWWWWWWWwwwwwwWWWWWWWWWWWWWWWwWW
WWWWWWWWWWWWWWWWWWWwWWWWWWWWWWWWWWW
WWWwwWWWWWWWWWWWWWWWWWwwWWWWWWWWWWW
WWWWWWwwwwwWWWWWWWWWWWWWWWWWWWWwwWW
WWWWWWWWWWWWWWWWWWWWwWWWWWWWWWWWWWW
WWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwwwww
wwWwwwwwwwwwwWWwwwwwwwWWWwwwwwwwWWW
WwWWWWWwwwwwwwwWWWWWWwwwwwwwwwwwwww
wwWWWWWWWwwwwwwwwwwwwwwwwwwwwWWWWWW
WWwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
wwwWWWWWWWWWwwwwWWWWWWWWWWwwwwwwwww
wwWWWWWWWWWWWwwwwwwwWWWWWWWWWWWWwww
wwwwwwwwwwwwwwwWWWWWWWWWWWWWwwwwwww
wwwwwwwwwwwwwwwwww
"""

type Grass4 = Grass<www4>
let grass4 = new Grass4()
grass4.Run() // Hello, world!
grass4.Value |> printfn "%s" // Hello, world!
```

# リソースから読めるように

拡張子 .www をプロジェクトに追加して「コンテンツ」にすると、読み込めるようにしました。

```Program.fs
// リソースから読み込む
type Grass5 = Grass<"www5.www">
let grass5 = new Grass4()
grass5.Run() // Hello, world!
grass5.Value |> printfn "%s" // Hello, world!
```

