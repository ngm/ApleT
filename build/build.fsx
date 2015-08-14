#r "tools/FAKE.4.1.3/tools/FakeLib.dll"
#r "tools/FSharp.Data.2.2.2/lib/net40/FSharp.Data.dll"
#r "System.Xml.Linq.dll"

open Fake
open Fake.FileUtils
open FSharp.Data

DeleteFile "./tests/specsPending.txt"

let readLines filePath = System.IO.File.ReadLines(filePath)

type NunitResults = XmlProvider<"./tests/TestResults.xml">
    
let alertFeaturesPending = fun _ ->
    CreateFile "./tests/specsPending.txt"

let customer = getBuildParam "customer"
setEnvironVar "customer" customer

// Directories
let srcDir = "../src"
let buildDir = "./build"
let testDir = "./tests"
let toolsDir = "./tools"
let picklesExe = "./tools/Pickles.CommandLine.1.0.0/tools/pickles.exe"
let specsDir = srcDir + "/variant.specs"

let nunitPath = (toolsDir + "/NUnit.Runners.2.6.4/tools")
let nunitExe = (nunitPath + "/nunit-console-x86.exe")

let specFlowPath = (toolsDir + "/SpecFlow.1.9.0/tools")

mkdir (testDir @@ customer)

RestorePackage (fun p ->
  { p with
      OutputPath = toolsDir
      Retries = 4 })
  "./packages.config"

Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "Build" (fun _ ->
    trace "Building"

    let buildMode = getBuildParamOrDefault "buildMode" "Release"

    let buildParams defaults = 
        { defaults with
            Properties = [
                "Configuration", buildMode
                "DeployOnBuild", "True"
                "PublishProfile", "webdeploy_pkg_ARC"
            ]
        }

    let solutionFile = !! (srcDir @@ "/variant.sln")
    let buildProperties = 
        [
            "Configuration","Release"
            "DeployOnBuild","True"
            "DeployTarget","Package"
        ]

    MSBuild buildDir "Build"  buildProperties solutionFile
        |> Log "Build-Output:"
)

Target "RunTests" (fun _ ->
    let features = readLines ("configs" @@ customer + ".config")
    let featuresString = features |> String.concat (",")
    let numberOfFeatures = features |> Seq.length

    !! (buildDir @@ "variant.specs.dll")
        |> NUnit (fun p ->
            {p with
                IncludeCategory = featuresString;
                DisableShadowCopy = true;
                ToolPath = nunitPath;
                OutputFile = (testDir @@ customer + "/TestResults.xml")})

    let results = NunitResults.GetSample()

    if (results.Total <> numberOfFeatures) then alertFeaturesPending()
)


Target "SpecFlowReport" (fun _ ->
    SpecFlow  (fun p ->
        {p with
            ProjectFile = (srcDir @@ "variant.specs/variant.specs.csproj");
            SubCommand = "nunitexecutionreport";
            ToolPath = specFlowPath;
            XmlTestResultFile = (testDir @@ customer) + "/TestResults.xml";
            OutputFile = (testDir @@ customer) + "/SpecflowReport.html"
            })
    ignore(cp_r ((testDir @@ customer) + "/SpecflowReport.html") ("C:/inetpub/specifications/variant" @@ customer + ".html") )
)

Target "Pickles" (fun _ ->
    ignore(Shell.Exec(picklesExe, (" -f=\"" + specsDir + "\" -o=" + testDir + "/pickles -df=dhtml")))
    ignore(cp_r (testDir + "/pickles") "C:/inetpub/specifications/variant/" )
)

FinalTarget "CheckPending" (fun _ ->
    if fileExists "./tests/specsPending.txt" then
        traceError "some specs are still pending"
    //let results = HtmlDocument.Load("C:/inetpub/specifications/variant" @@ customer + ".html")
    //CreateFile "test.txt"
    //WriteStringToFile true "test.txt" (results.ToString())
)

ActivateFinalTarget "CheckPending"


// --------------------------------------------------------------------------------------
// Help
Target "Help" <| fun () ->
    printfn ""
    printfn " Please specify the target by calling 'build <Target>'"
    printfn ""
    printfn " Targets for building:"
    printfn " * Build"
    printfn " * BuildTests"
    printfn " * RunTests"
    printfn " * All (calls previous 3)"
    printfn ""
    printfn ""

Target "All" DoNothing

"Clean" ==> "Build"
"Build" ==> "All"
"RunTests" ==> "All"
"SpecFlowReport" ==> "All"

RunTargetOrDefault "Help"


