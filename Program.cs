// This code is adapted from Jerry's code snippet on Stack Overflow: 
// https://stackoverflow.com/questions/58034425/download-file-from-sharepoint-online-using-c-net

using System;
using System.IO;
using System.Security;
using Microsoft.SharePoint.Client;

namespace CSOM
{
    class Program
    {
        static void Main(string[] args)
        {
            string sharePointSite = "https://tenantname.sharepoint.com/sites/sitename/"; // replace https://tenantname.sharepoint.com/sites/sitename/ with your SharePoint site
            using (ClientContext ctx = new ClientContext(sharePointSite)) 
            { 
                string account = "username@tenantname.onmicrosoft.com"; // replace username@tenantname.onmicrosoft.com with your account
                string password = "password"; // replace password with your password 
                var secretPassword = new SecureString();
                
                foreach (char c in password)
                {
                    secretPassword.AppendChar(c);
                }
                ctx.Credentials = new SharePointOnlineCredentials(account, secretPassword);
                ctx.Load(ctx.Web);
                ctx.ExecuteQuery();

                string libraryTitle = "libTitle"; // replace libTitle with your Document library name
                List list = ctx.Web.Lists.GetByTitle(libraryTitle); 

                string url = "/sites/sitename/shared documents/foldername"; // replace /sites/sitename/shared documents/foldername with your Document library folder
                FileCollection files = list.RootFolder.Folders.GetByUrl(url).Files;

                ctx.Load(files);
                ctx.ExecuteQuery();

                foreach (Microsoft.SharePoint.Client.File file in files)
                {
                    FileInformation fileinfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, file.ServerRelativeUrl);
                    ctx.ExecuteQuery();
                    string localDirectory = "C:/Users/MyFiles/"; // replace C:/Users/MyFiles/ with your download destination 

                    using (FileStream filestream = new FileStream(localDirectory + file.Name, FileMode.Create)) 
                    {
                        fileinfo.Stream.CopyTo(filestream);
                    }
                }
                Console.WriteLine("Successfully downloaded & updated file(s).");
            };
        }
    }
}