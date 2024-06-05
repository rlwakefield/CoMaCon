using COMACON.config;

namespace COMACON.ComaconHelper;

/// <summary>
/// Options for the proxy
/// </summary>
public class ComaconHelperProxyOptions
{
    /// <summary>
    /// The path the the COMACON Helper executable
    /// </summary>
    public string ExecutableFilePath { get; init; }
    /// <summary>
    /// The web application data structures object to be able to retrieve arrays and dictionaries accordingly.
    /// </summary>
    public WebApplicationDataStructures webApplicationDataStructures { get; init; }
}
