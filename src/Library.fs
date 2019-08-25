namespace Github.Dsaouda.FormatXml
open System.IO
open System.Text
open System.Xml

module Xml =
    
    let format xml =
        use mStream = new MemoryStream()
        use writer = new XmlTextWriter(mStream, Encoding.Unicode)
        let document = new XmlDocument()
        
        document.LoadXml(xml)
        
        writer.Formatting <- Formatting.Indented
        document.WriteContentTo(writer)
        writer.Flush()
        mStream.Flush()
        
        mStream.Position <- int64(0)
        let sReader = new StreamReader(mStream)
        sReader.ReadToEnd()
    
    let formatFile file = format(File.ReadAllText file)