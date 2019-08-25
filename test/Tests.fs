module Tests

open Github.Dsaouda.FormatXml
open System
open System.Xml
open Xunit

[<Fact>]
let ``When entry in line XML expect XML formatted`` () =
    let xml = "<test><lang>F#</lang><lang>C#</lang></test>"
    let xmlFormatted = "<test>
  <lang>F#</lang>
  <lang>C#</lang>
</test>"

    let formatted = Xml.format xml
    
    Assert.Equal(xmlFormatted, formatted)

[<Fact>]
let ``When entry invalid XML expect Exception`` () =
    let xml = "<test><language>F#</lang><lang>C#</lang></test>"
    Assert.Throws<XmlException>(fun () -> Xml.format xml |> ignore)