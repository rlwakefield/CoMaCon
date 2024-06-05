using COMACON.config;
using System.Diagnostics;

namespace COMACON.ComaconHelper;

internal class DefaultComaconHelperProxy : ComaconHelperProxy
{
    private readonly string FilePath;
    private readonly WebApplicationDataStructures webApplicationDataStructures;

    public DefaultComaconHelperProxy(ComaconHelperProxyOptions options)
    {
        FilePath = options.ExecutableFilePath;
        webApplicationDataStructures = options.webApplicationDataStructures;
    }

    public string Set(string applicationPath, string applicationName, string applicationType, string serializedOutputObject, string version)
    {
        var args = generateSetArguments(applicationPath, applicationName, applicationType, serializedOutputObject);
        //Console.WriteLine(args);
        using var process = CreateProcess(args, version);

        process.Start();

        string serializedObject = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return serializedObject;
    }

    public string Get(string applicationPath, string applicationName, string applicationType, string version)
    {
        var args = generateGetArguments(applicationPath, applicationName, applicationType, webApplicationDataStructures.getWebApplicationDataStructureDictionary(applicationType, version));
        Console.WriteLine(args);

        using var process = CreateProcess(args, version);

        process.Start();

        string serializedObject = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return serializedObject;
    }

    private Process CreateProcess(string args, string version)
    {
        Process process = new();

        switch (version)
        {
            case "211":
            case "221":
            case "231":
                process.StartInfo.FileName = @"OtherDependencies\231AndUnder\COMACON Helper.exe";
                process.StartInfo.Arguments = args;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                break;
            case "241":
                process.StartInfo.FileName = FilePath;
                process.StartInfo.Arguments = args;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                break;
        }
        
        return process;
    }

    internal string generateGetArguments(string applicationPath, string applicationName, string applicationType, string translator)
    {
        //argument 1
        string action = "get";
        //argument 2
        string appPath = Path.Combine(applicationPath, applicationName);
        //argument 3
        string args = $"\"{action}\" \"{appPath}\" \"{applicationType}\" \"{null}\" \"{translator.Replace("\"", "\"\"")}\"";

        return args;
    }

    public string generateSetArguments(string applicationPath, string applicationName, string type, string serializedOutput)
    {
        //// Start the process
        //argument 1
        string action = "set";
        //argument 2
        //string subAction = "";
        //argument 3
        string appPath = Path.Combine(applicationPath, applicationName);
        //argument 4
        //string sectionsToLoad = "";
        //argument 5
        //string nothing = "";
        //argument 6
        string webApplicationType = type;
        //argument 7
        string serializedobject = serializedOutput.Replace("\"", "\"\"");
        //string args = $"\"{action}\" \"{subAction}\" \"{appPath}\" \"{sectionsToLoad}\" \"{nothing}\" \"{webApplicationType}\" \"{serializedobject}\"";
        string args = $"\"{action}\" \"{appPath}\" \"{webApplicationType}\" \"{serializedobject}\"";


        return args;
    }
}
