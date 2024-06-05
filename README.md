# COMACON MVC
This is my personal concept of what a web based version of the WAMCON (Web Application Management Console) could look like. However, I have invisioned a slightly different approach to it than Hyland has. I envision this being more of a COMACON (Configuration Management Console). Fetures I want to have in it are as follows:

1. Configuration/Management of web based configuration files (same as WAMCON today, but much cleaner, accurate, and detailed)
2. Configuration of local configuration files (e.g. obunity.exe.config and more)
3. Creation of brand new web based applications (Application Server, Web Server, etc.)
4. Creation of brand new local configuration files (Unity Client, Thick Client, etc.)

![image](https://github.com/rlwakefield/COMACON-MVC/assets/33588807/cc7c6524-2926-4b2b-bcb9-c2875a62c9ce)


# Installation Instructions
__$${\color{red}This \space will \space be \space changed/updated \space as \space soon \space as \space I \space get \space the \space BETA \space fully \space up \space and \space running.}$$__
Please follow the following steps to install and setup COMACON in your environment. (NOTE: Make sure you are in the "main" branch to do the installation.)
# PREREQS
You will need to install the .NET 6.0 Windows Hosting Bundle on the server you are using to test this. You can find it here: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
# Core Installation
1. (1)Click on the green "Code" button and (2) choose to "Download ZIP".
![image](https://github.com/rlwakefield/COMACON-MVC/assets/33588807/003eb29d-c3a4-4792-8a54-90868ffc18e9)
2. Once the file downloads, then unzip it.
3. Open the unzipped folder and navigate to "COMACON-MVC-main\COMACON" and locate the "v0.1.0.zip" ZIP file. You will want to unzip and extract the files out of this file.
4. Now you will need to copy these files into a folder under "C:\inetpub\wwwroot".
5. Now go into IIS and go to your Application Pools. You will want to create a NEW application pool called "COMACON" and have it configured the save as the DefaultAppPool Application Pool.
6. Next you will want to convert this newly created folder (from step #4) to an Application. Use the newly created Application Pool in step #5 on this application.
7. The last step you will need to do is you will need to update the user that is running the Application Pool for the COMACON to an admin user. The reason for this is because a lot of the code used needs to have elevated rights in order to run and unfortunately, there really isn't a way around this. So this is a step that needs to happen. This can be done by going to the Application Pools --> Click on the COMACON Application Pool --> Click Advanced Settings in the right-hand pane --> locate the Identity element and then click the 3 dot button in the field --> Change the type to "Custom Account" and then click on the Set... button --> type in the username, password, and confirm password and then just save everything. (NOTE: I am working on getting this cahnged so the user doesn't have to be an admin, but at this point in time, it is needed due to some of the means of reading and updating IIS settings.)
8. At this point, COMACON should be available to be loaded by going to your browser and going to the URL of "http://{servername}/COMACON" or "https://{servername}/COMACON" (if your server is configured for HTTPS communications.)

Please make sure to open any issues whenever you encounter them. I might need to get a copy of the web.config file that you were working with so I can do further testing on my side. Of course, please remove any PII from the files as I would hate to eassume that risk. 😄 Thanks!


# Future Enhancements
1. Configuration of local configuration files on servers directly. Examples include Full Text Search, Data Capture Server, etc.
2. Creation/Configuration of Thick Client Windows Services (instead of needing to do them through the Configuration Client installed on that server directly).

Obviously I am always open to other features, suggestions, etc., but right now my focus is to get this up and working as similar to the WAMCON as I can.


# Upgrade Instructions
(TBD)


# Issue Reporting/Enhancement Suggestions
I am always up for new enhancements, but the ultimate game is that I will be working on bugs at first. Once I get those out of the way for the most part, then I will be working on more of the enhancements.


Thanks for all of your support in helping me making this thing a potential reality!
