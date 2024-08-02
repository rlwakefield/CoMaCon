using Microsoft.Web.Administration;
using Newtonsoft.Json;
using System.Xml;
using COMACON.config;

namespace COMACON.config;

public interface Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newApplicationPoolName"></param>
    /// <param name="newApplicationName"></param>
    /// <param name="webApplicationVersion"></param>
    /// <param name="newApplicationPathName"></param>
    /// <param name="newSiteName"></param>
    /// <param name="newApplicationServerUrl"></param>
    /// <param name="currentApplicationPoolName"></param>
    /// <param name="currentApplicationName"></param>
    /// <param name="currentApplicationPathName"></param>
    /// <param name="currentSiteName"></param>
    /// <param name="currentPhysicalPath"></param>
    /// <returns>
    /// 
    /// </returns>
    public string CopyWebApplication(string newApplicationPoolName,
            string newApplicationName,
            string newApplicationPathName,
            string newSiteName,
            string newApplicationServerUrl,
            string currentApplicationPoolName,
            string currentApplicationName,
            string currentApplicationPathName,
            string currentSiteName,
            string currentPhysicalPath);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="physicialPath"></param>
    /// <param name="newApplicationName"></param>
    /// <param name="siteName"></param>
    /// <param name="applicationPath"></param>
    /// <param name="currentApplicationName"></param>
    /// <returns>
    /// 
    /// </returns>
    public Boolean CheckDuplicateWebApplication(string physicialPath,
        string newApplicationName,
        string siteName,
        string applicationPath,
        string currentApplicationName);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appPoolName"></param>
    /// <returns>
    /// 
    /// </returns>
    public Boolean CheckDuplicateWebApplicationPool(string appPoolName);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public string RetrieveWebApplications();
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
}

internal sealed class DefaultCore : Core
{
    private readonly GenericHelperMethods GenericHelperMethods;

    public DefaultCore(GenericHelperMethods genericHelperMethods)
    {
        GenericHelperMethods = genericHelperMethods;
    }

    public string CopyWebApplication(string newApplicationPoolName,
            string newApplicationName,
            string newApplicationPathName,
            string newSiteName,
            string newApplicationServerUrl,
            string currentApplicationPoolName,
            string currentApplicationName,
            string currentApplicationPathName,
            string currentSiteName,
            string currentPhysicalPath)
    {
        /* Here are the different things that need to be done:
        * 1. Copy the files from the original folder to the new folder location.
        *   a. Create all of the folders recursively.
        *   b. Copy all of the files recursively.
        *   c. Example code here: https://stackoverflow.com/questions/2742300/what-is-the-best-way-to-copy-a-folder-and-all-subfolders-and-files-using-c-sharp
        * 2. Create the new Application Pool.
        * 3. Set all of the settings from the previous Application Pool to the new one. Specifically:
        *   a. General
        *       i. .NET CLR Version
		*		ii. Enable 32-Bit Applications
        *       iii. Managed Pipeline Mode
		*		iv. Queue Length
        *       v. Start Mode
		*	b. CPU
        *       i. Limit Interval (minutes)
		*	c. Process Model
        *       i. Identity
		*		ii. Identity (Username)
        *       iii. Identity (Password)
		*		iv. Idle Timeout-out (minutes)
        *       v. Ping Enabled
		*	d. Rapid-Fail Protection
        *       i. Enabled
		*	e. Recycling
        *       i. Regular Time Interval (minutes)
        * 4. Create the new Application. Make sure that it includes the Site Name and Application Path passed through to the method.
        * 5. Set the Application Pool to be used to the one that was just created.
        * 6. Update the appSettings/dmsVirtualRoot in the web.config file to the new Application Name. 
        * 7. Update the Hyland.Services.Client/ApplicationServer.Url to the input Application Server URL.
        * 8. Start applying all of the settings that are stored in the applicationHost.config file instead of the normal web.config that were applied to the previous Application.
        *    This is settings applied to the Application at the "location" level like the authentication.
        *    Otherwise, other settings are applied at the Application level like Preload Enabled and such.
        * 9. 
        */

        //Generic variable creation.
        ServerManager manager = new ServerManager();
        ApplicationPool oldPool = manager.ApplicationPools[currentApplicationPoolName];
        XmlDocument newConfiguration = new XmlDocument();

        /*
        * 1. Copy the files from the original folder to the new folder location.
        *   a. Create all of the folders recursively.
        *   b. Copy all of the files recursively.
        *   c. Example code here: https://stackoverflow.com/questions/2742300/what-is-the-best-way-to-copy-a-folder-and-all-subfolders-and-files-using-c-sharp
        */
        //Directory.CreateDirectory(@"C:\inetpub\wwwroot\app\AppServer");
        string sourcePath = currentPhysicalPath;
        string targetPath = "";
        string updatedNewApplicationPathName = newApplicationPathName.Replace("/", @"\");
        //Console.WriteLine(updatedNewApplicationPathName);
        //Thread.Sleep(1000000);

        //Testing new code.
        targetPath = manager.Sites[newSiteName].Applications["/"].VirtualDirectories["/"].PhysicalPath.Replace("%SystemDrive%", Environment.GetEnvironmentVariable("SystemDrive")) + updatedNewApplicationPathName + newApplicationName + "\\";

        // Create all of the directories
        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
        }

        // Copy all the files & Replaces any files with the same name
        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
        {
            File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
        }

        /*
        * 2. Create the new Application Pool.
        */
        ApplicationPool newPool = manager.ApplicationPools.Add(newApplicationPoolName);

        /*
        * 3. Set all of the settings from the previous Application Pool to the new one. Specifically:
        *   a. General
        *       i. .NET CLR Version
		*		ii. Enable 32-Bit Applications
        *       iii. Managed Pipeline Mode
		*		iv. Queue Length
        *       v. Start Mode
		*	b. CPU
        *       i. Limit Interval (minutes)
		*	c. Process Model
        *       i. Identity
		*		ii. Identity (Username)
        *       iii. Identity (Password)
		*		iv. Idle Timeout-out (minutes)
        *       v. Ping Enabled
		*	d. Rapid-Fail Protection
        *       i. Enabled
		*	e. Recycling
        *       i. Regular Time Interval (minutes)
        */

        //General Settings
        newPool.ManagedRuntimeVersion = "v4.0";
        newPool.Enable32BitAppOnWin64 = false;
        newPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
        newPool.QueueLength = 65535;
        newPool.StartMode = StartMode.AlwaysRunning;

        //CPU Settings
        TimeSpan timeSpan = TimeSpan.FromMinutes(5);
        newPool.Cpu.ResetInterval = timeSpan;

        //Process Model Settings
        switch (oldPool.ProcessModel.IdentityType)
        {
            case ProcessModelIdentityType.SpecificUser:
            case ProcessModelIdentityType.NetworkService:
                newPool.ProcessModel.IdentityType = oldPool.ProcessModel.IdentityType;
                newPool.ProcessModel.UserName = oldPool.ProcessModel.UserName;
                newPool.ProcessModel.Password = oldPool.ProcessModel.Password;
                break;
            case ProcessModelIdentityType.LocalSystem:
            case ProcessModelIdentityType.ApplicationPoolIdentity:
            case ProcessModelIdentityType.LocalService:
                newPool.ProcessModel.IdentityType = oldPool.ProcessModel.IdentityType;
                break;
        }
        newPool.ProcessModel.IdleTimeout = oldPool.ProcessModel.IdleTimeout;
        newPool.ProcessModel.PingingEnabled = false;

        //Rapid Fail Protection Settings
        newPool.Failure.RapidFailProtection = false;

        //Recycling Settings
        newPool.Recycling.PeriodicRestart.Time = TimeSpan.FromMinutes(0);

        /*
        * 4. Create the new Application. Make sure that it includes the Site Name and Application Path passed through to the method.
        */
        Application newApplication = manager.Sites[newSiteName].Applications.Add(newApplicationPathName + newApplicationName, targetPath);

        /*
        * 5. Set the Application Pool to be used to the one that was just created.
        */
        newApplication.ApplicationPoolName = newApplicationPoolName;

        /*
        * 6. Update the appSettings/dmsVirtualRoot in the web.config file to the new Application Name.
        */
        // ! TODO: Need to figure out the right logic for when switching folder locations, but also for potential switching of sites.
        string currentDmsVirtualRoot = manager.Sites[currentSiteName].Applications[currentApplicationPathName + currentApplicationName].GetWebConfiguration().GetSection("appSettings").GetCollection().FirstOrDefault(e => (string)e["key"] == "dmsVirtualRoot").GetAttributeValue("value").ToString();
        //Console.WriteLine("Current DMS Virtual Root: " + currentDmsVirtualRoot);
        //Console.WriteLine(currentApplicationName);
        //Console.WriteLine(newApplicationName);
        manager.Sites[newSiteName].Applications[newApplicationPathName + newApplicationName].GetWebConfiguration().GetSection("appSettings").GetCollection().FirstOrDefault(e => (string)e["key"] == "dmsVirtualRoot").SetAttributeValue("value", currentDmsVirtualRoot.Replace(currentApplicationName, newApplicationName));

        /*
        * 7. Update the Hyland.Services.Client/ApplicationServer.Url to the input Application Server URL.
        */
        // newConfiguration.Load(targetPath + @"\web.config");
        // newConfiguration.DocumentElement.SelectSingleNode("Hyland.Services.Client").SelectSingleNode("ApplicationServer").Attributes["Url"].Value = newApplicationServerUrl;

        /*
        * 8. Start applying all of the settings that are stored in the applicationHost.config file instead of the normal web.config that were applied to the previous Application.
        *    This is settings applied to the Application at the "location" level like the authentication.
        *    Otherwise, other settings are applied at the Application level like Preload Enabled and such.
        */
        string currentApplicationFullPath = currentSiteName + currentApplicationPathName + currentApplicationName;
        string newApplicationFullPath = newSiteName + newApplicationPathName + newApplicationName;
        string[] currentLocationPaths = manager.GetApplicationHostConfiguration().GetLocationPaths().Where(value => value.StartsWith(currentApplicationFullPath)).ToArray();
        manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/anonymousAuthentication").OverrideMode = OverrideMode.Allow;
        manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/windowsAuthentication").OverrideMode = OverrideMode.Allow;

        foreach (string path in currentLocationPaths)
        {
            //Console.WriteLine("ApplicationHost Config Location: " + path);
            if (path == currentApplicationFullPath)
            {
                //Setting the authentication at the root level of the site.
                manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/anonymousAuthentication", newSiteName + newApplicationPathName + newApplicationName).Attributes["enabled"].Value = manager.GetWebConfiguration(currentSiteName + currentApplicationPathName + currentApplicationName).GetSection(@"system.webServer/security/authentication/anonymousAuthentication").GetAttributeValue("enabled");
                manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/windowsAuthentication", newSiteName + newApplicationPathName + newApplicationName).Attributes["enabled"].Value = manager.GetWebConfiguration(currentSiteName + currentApplicationPathName + currentApplicationName).GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("enabled");
                manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/windowsAuthentication", newSiteName + newApplicationPathName + newApplicationName).Attributes["useAppPoolCredentials"].Value = manager.GetWebConfiguration(currentSiteName + currentApplicationPathName + currentApplicationName).GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("useAppPoolCredentials");
            }
            else
            {
                string virtualPathValue = path.Substring(currentApplicationFullPath.Length);
                //Console.WriteLine(virtualPathValue);
                //Console.WriteLine(newApplicationPathName+newApplicationName+virtualPathValue);
                //Console.WriteLine(newSiteName);
                manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/anonymousAuthentication", newSiteName + newApplicationPathName + newApplicationName).Attributes["enabled"].Value = manager.GetWebConfiguration(currentSiteName, currentApplicationPathName + currentApplicationName + virtualPathValue).GetSection(@"system.webServer/security/authentication/anonymousAuthentication").GetAttributeValue("enabled");
                manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/windowsAuthentication", newSiteName + newApplicationPathName + newApplicationName).Attributes["enabled"].Value = manager.GetWebConfiguration(currentSiteName, currentApplicationPathName + currentApplicationName + virtualPathValue).GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("enabled");
                manager.GetApplicationHostConfiguration().GetSection(@"system.webServer/security/authentication/windowsAuthentication", newSiteName + newApplicationPathName + newApplicationName).Attributes["useAppPoolCredentials"].Value = manager.GetWebConfiguration(currentSiteName, currentApplicationPathName + currentApplicationName + virtualPathValue).GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("useAppPoolCredentials");
            }
        }
        //Unsure if there are other settings that I need to set or not, but this should be good to go hopefully.

        //Setting the option of Pre-Load Enabled to true. Need to fix the code.
        manager.Sites[newSiteName].Applications[newApplicationPathName + newApplicationName].Attributes["preloadEnabled"].Value = true;

        //Saving this code for the very VERY end.
        manager.CommitChanges();

        newConfiguration.Load(targetPath + @"\web.config");
        newConfiguration.DocumentElement.SelectSingleNode("Hyland.Services.Client").SelectSingleNode("ApplicationServer").Attributes["Url"].Value = newApplicationServerUrl;
        //Console.WriteLine("New App Server URL: "+newApplicationServerUrl);
        newConfiguration.Save(targetPath + @"\web.config");

        return targetPath;
    }

    public Boolean CheckDuplicateWebApplication(string physicialPath,
        string newApplicationName,
        string siteName,
        string applicationPath,
        string currentApplicationName)
    {
        /* Some notes on the logic to be performed here:
        * 1. If there is no folder, need to validate that there isn't an existing Application named what we want to name the new one. (NOTE: Only need to check the same path. Different paths with the same name are fine.)
        * 2. Check and make sure there is no actual folder existing in the folder location.
        * 3.  */
        ServerManager manager = new ServerManager();
        string folderToCheck = manager.Sites[siteName].Applications["/"].VirtualDirectories["/"].PhysicalPath.Replace("%SystemDrive%", Environment.GetEnvironmentVariable("SystemDrive")) + newApplicationName;
        //string folderToCheck = physicalPath.Replace(currentApplicationName, newApplicationName);
        //Checks if the "Physical" folder exists.
        // Console.WriteLine(physicalPath + @"\" + newApplicationName);
        if (Directory.Exists(folderToCheck))
        { //"Default Web Site/app/AppServer64"
            return false;
            //Checks if there is an existing Application with the same name in the same virtual path and under the same site.
        }
        else if (manager?.Sites[siteName]?.Applications[applicationPath + newApplicationName] != null)
        {
            return false;
            //Assumes the value is unique.
        }
        else
        {
            return true;
        }
    }

    public Boolean CheckDuplicateWebApplicationPool(string appPoolName)
    {
        /* Some notes on the logic to be performed here:
        * 1. Just need to make sure that there isn't a previously created AppPool named the same name.  */
        ServerManager manager = new ServerManager();
        Microsoft.Web.Administration.ApplicationPool appPool = manager.ApplicationPools[appPoolName];
        if (manager?.ApplicationPools[appPoolName]?.ToString() == null)
        {
            //Returns false saying that the Application Pool Name entered IS unique.
            return true;
        }
        else
        {
            //Returns false saying that the Application Pool Name entered is NOT unique.
            return false;
        }
    }

    public string RetrieveWebApplications()
    {
        WebApplications webApplications = new WebApplications();
        ServerManager manager = new ServerManager();
        foreach (Site site in manager.Sites)
        {
            foreach (Application app in site.Applications)
            {
                if (app.Path.Length > 0)
                {
                    ApplicationDetails applicationDetails = new ApplicationDetails();
                    applicationDetails.name = app.Path.Substring(app.Path.LastIndexOfAny(new char[] { '/' }) + 1);

                    foreach (VirtualDirectory vdir in app.VirtualDirectories)
                    {
                        applicationDetails.type = GenericHelperMethods.findWebApplicationType(vdir);
                        applicationDetails.version = GenericHelperMethods.findWebApplicationVersion(applicationDetails.type, vdir);
                        applicationDetails.webConfigPhysicalPath = vdir.PhysicalPath + @"\web.config";
                        applicationDetails.physicalPath = vdir.PhysicalPath;
                        /* Here is a link to a page that shows how to check the bitness of a file. https://stackoverflow.com/questions/1001404/check-if-unmanaged-dll-is-32-bit-or-64-bit*/
                        applicationDetails.bitness = (GenericHelperMethods.getWebApplicationBitness(applicationDetails.type, vdir) == "True") ? "64-Bit" : "32-Bit";
                    }

                    applicationDetails.site = site.Name;
                    applicationDetails.path = app.Path.Substring(0, app.Path.LastIndexOfAny(new char[] { '/' }) + 1);

                    if (applicationDetails.type != "None")
                    {
                        webApplications.webApps.Add(applicationDetails);
                    }
                }
            }
        }

        // Console.WriteLine(JsonConvert.SerializeObject(webApplications));

        return JsonConvert.SerializeObject(webApplications);
    }
}