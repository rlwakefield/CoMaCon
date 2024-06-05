namespace COMACON.ComaconHelper;

/// <summary>
/// A proxy class for the COMACON helper executable
/// </summary>
public interface ComaconHelperProxy
{
    /// <summary>
    /// Sets the config file
    /// </summary>
    /// <param name="applicationPath">The path to the web application.</param>
    /// <param name="applicationName">The name of the web application.</param>
    /// <param name="applicationType">The type of web applications</param>
    /// <param name="serializedOutput">The serialized config file to save.</param>
    /// <param name="version">The version of the config file.</param>
    /// <returns>
    /// ...
    /// </returns>
    public string Set(string applicationPath, string applicationName, string applicationType, string serializedOutput, string version);
    /// <summary>
    /// Gets the config file.
    /// </summary>
    /// <param name="applicationPath">The path to the web application.</param>
    /// <param name="applicationName">The name of the web application.</param>
    /// <param name="applicationType">The type of web applications</param>
    /// <param name="version">The version of the config file.</param>
    /// <returns>
    /// The serialized config file.
    /// </returns>
    public string Get(string applicationPath, string applicationName, string applicationType, string version);
}
