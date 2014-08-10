﻿namespace TypeProvider.Sample
open System.IO
open System.Reflection
open Microsoft.FSharp.Core.CompilerServices
open ProviderImplementation.ProvidedTypes

[<TypeProvider>]
type GrassTypeProvider(config: TypeProviderConfig) as this =
  inherit TypeProviderForNamespaces()

  let asm = Assembly.GetExecutingAssembly()
  let ns = "GrassTypeProvider"

  let typ = ProvidedTypeDefinition(asm, ns, "Grass", Some (typeof<obj>), HideObjectMethods = true)
  do typ.DefineStaticParameters(
        [ProvidedStaticParameter("grassCode", typeof<string>)],
        fun typeName parameters ->
              let grassCode = 
                let str = string parameters.[0]
                if str.EndsWith(".www") = false then
                  str
                else
                  let path = Path.Combine(config.ResolutionFolder, str)
                  try
                    File.ReadAllText(path)
                  with
                  | _ -> 
                      failwithf "Error www path %A" path
              let typ = ProvidedTypeDefinition(asm, ns, typeName, Some typeof<obj>, HideObjectMethods = true)
              let ctor = ProvidedConstructor(parameters = [ ], 
                                             InvokeCode= (fun args -> <@@ grassCode :> obj @@>))
              typ.AddMember ctor
              typ.AddMemberDelayed(fun () -> 
                let result = Grass.run grassCode
                let instanceMeth = 
                  ProvidedMethod(methodName = "Run", 
                                  parameters = [], 
                                  returnType = typeof<unit>, 
                                  InvokeCode = (fun _ -> <@@ result |> printfn "%s" @@>))
                instanceMeth.AddXmlDocDelayed (fun () -> System.String.Format("\"{0}\"を出力します。", result))
                instanceMeth)

              typ.AddMemberDelayed(fun () -> 
                let result = Grass.run grassCode
                let instanceProp = 
                  ProvidedProperty(propertyName = "Value", 
                                   propertyType = typeof<string>, 
                                   GetterCode= (fun _ -> <@@ result @@>))
                instanceProp.AddXmlDocDelayed (fun () -> System.String.Format("出力結果\"{0}\"を取得します。", result))
                instanceProp)

              typ.HideObjectMethods <- true
              typ
  )
  do this.AddNamespace(ns, [typ])
  
[<assembly:TypeProviderAssembly>] 
do()