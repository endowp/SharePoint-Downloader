# SharePoint-Downloader
C# .NET4.8 code for download files from SharePoint online

### Required Package
- Microsoft.SharePoint.Client
- Microsoft.Sharepoint.Client.Online.CSOM
- Microsoft.SharePoint.Client.Runtime
- Microsoft.SharePointOnline.CSOM

### Manual
<img src="https://github.com/endowp/SharePoint-Downloader/blob/main/image/site_screenshot.jpg" width=70% hight=70%>
Suppose you want to download all files in the "downloadMe" folder.
You have to change the code as follows. 

#### line 15
``` C#
string sharePointSite = "https://xxxxx.sharepoint.com/sites/TestEmailGroup/";
```

#### line 18 and 19 
change account and password to your account and password.

#### line 30
``` C#
string libraryTitle = "testtest";
```

#### line 33 
``` C#
string url = "/sites/TestEmailGroup/testtest/download";
```

#### line 43 
Change localDirectory to the destination folder on your computer as you wish.
