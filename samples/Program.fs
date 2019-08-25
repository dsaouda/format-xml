open Github.Dsaouda.FormatXml
open System

[<EntryPoint>]
let main argv =
    let formatted = Xml.format "<test><lang>F#</lang><lang>C#</lang></test>"
    Console.WriteLine formatted
    0