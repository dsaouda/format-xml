open Github.Dsaouda.FormatXml
open System
open System.IO


let usage = fun () ->
    printfn "Usage: format-xml <directory>"
    printfn ""
    printfn "directory: Input directory with file for formatting"
    

let formatFilesIn directory = fun () ->
    
    let files = Directory.GetFiles directory
    for file in files do
        let fileinfo = new FileInfo(file)
        
        let formatted = (Xml.formatFile file)
        let newFilename = (String.Format("__formatted-{0}", fileinfo.Name))
        let dir = String.Format("{0}/{1}", directory, newFilename)
        File.WriteAllText(dir, formatted)
        printfn "new file %s" dir
        
        
[<EntryPoint>]
let main argv =
    
    if argv.Length = 0 then usage()
    else formatFilesIn argv.[0]()
    0