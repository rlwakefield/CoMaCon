# COMACON MVC
This is my personal concept of what a web based version of the WAMCON (Web Application Management Console) could look like. However, I have invisioned a slightly different approach to it than Hyland has. I envision this being more of a COMACON (Configuration Management Console). Fetures I want to have in it are as follows:

1. Configuration/Management of web based configuration files (same as WAMCON today, but much cleaner, accurate, and detailed)
2. Configuration of local configuration files (e.g. obunity.exe.config and more) - To Be Released
3. Creation of brand new web based applications (Application Server, Web Server, etc.) - To Be Released
4. Creation of brand new local configuration files (Unity Client, Thick Client, etc.) - To Be Released

![image](https://github.com/rlwakefield/COMACON-MVC/assets/33588807/cc7c6524-2926-4b2b-bcb9-c2875a62c9ce)


# Installation Instructions
### PREREQS
You will need to install the .NET 8.0 Windows Hosting Bundle on the server you are using to test this. You can find it here: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
You will also need to have IIS installed and configured on the server you wish to have hosting the COMACON.

### Core Installation
1. Download the latest release [here](https://github.com/rlwakefield/CoMaCon/releases).
2. Once the file downloads, right-click on it and select properties. Then unblock the file and click OK.
3. Copy the .zip file to the server that will be hosting the COMACON.
**On the server hosting the COMACON**
4. Unzip the copied .zip file.
5. Now go into IIS and go to the Application Pools. Create a NEW application pool called "COMACON" and leave default settings.
6. Open up File Explorer and navigate to "C:\inetpub\wwwroot".
7. Create a folder named "COMACON" here.
8. Copy the files extracted from the .zip file in step #4 above into the folder created in step #7.
9. Go back into IIS and right-click on the Default Site and click refresh.
10. Expand the Default Site and locate a folder called "COMACON".
11. Right-click on that folder and select "Convert to Application".
12. Change the Application Pool to the COMACON one and then click OK.
13. Finally, you need to update the user running the Application Pool to be an administrator on the server. This is due to code being used to read/write IIS settings. This can be done by going to the Application Pools --> Click on the COMACON Application Pool --> Click Advanced Settings in the right-hand pane --> locate the Identity element and then click the 3 dot button in the field --> Change the type to "Custom Account" and then click on the Set... button --> type in the username, password, and confirm password and then just save everything. (NOTE: I am working on getting this cahnged so the user doesn't have to be an admin, but at this point in time, it is needed due to some of the means of reading and updating IIS settings.)
11. At this point, COMACON should be available to be loaded by going to your browser and going to the URL of "http://{servername}/COMACON" or "https://{servername}/COMACON" (if your server is configured for HTTPS communications.)

Please make sure to open any issues whenever you encounter them. I might need to get a copy of the web.config file that you were working with so I can do further testing on my side. Of course, please remove any PII from the files as I would hate to assume that risk. 😄 Thanks!


# Future Enhancements
1. Configuration of local configuration files on servers directly. Examples include Full Text Search, Data Capture Server, etc.
2. Creation/Configuration of Thick Client Windows Services (instead of needing to do them through the Configuration Client installed on that server directly).

Obviously I am always open to other features, suggestions, etc., but right now my focus is to get this up and working as similar to the WAMCON as I can.


# Upgrade Instructions
1. verify you have the appropriate .NET Windows Hosting Bundle installed.
2. Download the latest release [here](https://github.com/rlwakefield/CoMaCon/releases).
3. Once the file downloads, right-click on it and select properties. Then unblock the file and click OK.
4. Copy the .zip file to the server that will be hosting the COMACON.
**On the server hosting the COMACON**
5. Unzip the copied .zip file.
6. Delete all of the files from the current COMACON folder in the "C:\inetpub\wwwroot\COMACON" folder.
7. Copy all of the files from the unzipped .zip file to the "C:\inetpub\wwwroot\COMACON" folder.
8. Recycle the COMACON Application Pool and you are good to go.


# Issue Reporting/Enhancement Suggestions
I am always up for new enhancements, but the ultimate game is that I will be working on bugs at first. Once I get those out of the way for the most part, then I will be working on more of the enhancements.


Thanks for all of your support in helping me making this thing a potential reality!
