<div align="center">

[![GitHub repo size](https://img.shields.io/github/repo-size/rwakefield/CoMaCon?style=flat-square)](#)
[![GitHub release (release name instead of tag name)](https://img.shields.io/github/v/release/rwakefield/CoMaCon?style=flat-square)](https://github.com/rwakefield/CoMaCon/releases/latest)
[![GitHub all releases](https://img.shields.io/github/downloads/rwakefield/CoMaCon/total?style=flat-square)](https://github.com/rwakefield/CoMaCon/releases/)

</div>

# COMACON MVC
This is my personal concept of what a web based version of the WAMCON (Web Application Management Console) could look like. However, my vision for this utility is not just a utility that configures web applications on the servers, but also allows for the configuration of client configuration files and more! My vision for this new Configuration Management Console's features are:

1. Configure any of your Web Application and their respective settings in a simple, easy to use, intuitive web based interface.
2. Centrally configure and manage all of your servers web applications so that all of the servers stay in sync with each other, helping to avoiding rogue configurations.
3. Centrally managed and maintain all of your client deployments and their respective configurations on all of your end users workstations.
4. Allow for the efficient handling of upgrades to any clients or server configurations from a central location.

As system administrators, one of the biggest challenges that we tend to face is the deployment of all of our different clients, servers, and their configurations and being able to maintain them easily.

With this utility, that challenge will become a thing of the past. No longer will you have to worry about your upgrades and whether all of your server configurations are the same or not. That will all be handled by this amazing new utility called the COMACON!

![image](https://github.com/rlwakefield/COMACON-MVC/assets/33588807/cc7c6524-2926-4b2b-bcb9-c2875a62c9ce)

Current supported versions include:
- [ X ] 21.1 (EP5)
- [ X ] 22.1
- [ X ] 23.1
- [ X ] 24.1
- [  ] 25.1


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
