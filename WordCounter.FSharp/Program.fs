open System
open Microsoft.FSharp.Core.Option

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let ReadFileToEnd(filePath : string) = System.IO.File.ReadLines(filePath) |> String.Concat

let GetSeparatorsInText(text : string) = query {
    for char in text do
    where (Char.IsPunctuation(char))
    distinct 
}

let ChangeSeparators(punctuation : seq<char>) =
     let seqArray = Seq.toArray(punctuation)
     Array.append seqArray [|' ';'\n';'\000'|] 

let GetAllWords (text : string, punctuation : char[]) =
   let charArray = Seq.toArray(punctuation)
   text.Split(charArray)

let GetWordGroups (words : string[]) =
    words |> Seq.groupBy(fun x -> x)


let printSeq seq1 = Seq.iter (printfn "%A ") seq1; printfn ""


[<EntryPoint>]
let main argv = 
    let text = ReadFileToEnd(@"..\..\..\FileTxt.txt")
    let separ = ChangeSeparators <| GetSeparatorsInText(text)

    let words = GetAllWords(text,separ)

    printSeq <| GetWordGroups(words)

    0 // return an integer exit code
