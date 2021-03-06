﻿using System;
using System.Net;
using Aspose.Email.Clients.Exchange.Dav;
using Aspose.Email.Mime;
using Aspose.Email.Clients.Exchange.WebService;
using Aspose.Email.Clients.Exchange;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Email for .NET API reference 
when the project is build. Please check https://Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Email for .NET API from https://www.nuget.org/packages/Aspose.Email/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/email
*/

namespace Aspose.Email.Examples.CSharp.Email.Exchange_EWS
{
    class DeleteMessagesFromusingEWS
    {
        public static void Run()
        {
            // ExStart:DeleteMessagesFromusingEWS
            
            // Create instance of IEWSClient class by giving credentials
            IEWSClient client = EWSClient.GetEWSClient("https://outlook.office365.com/ews/exchange.asmx", "testUser", "pwd", "domain");

            ExchangeMailboxInfo mailboxInfo = client.GetMailboxInfo();

            // List all messages from Inbox folder
            Console.WriteLine("Listing all messages from Inbox....");
            ExchangeMessageInfoCollection msgInfoColl = client.ListMessages(mailboxInfo.InboxUri);
            foreach (ExchangeMessageInfo msgInfo in msgInfoColl)
            {
                // Delete message based on some criteria
                if (msgInfo.Subject != null && msgInfo.Subject.ToLower().Contains("delete") == true)
                {
                    client.DeleteItem(msgInfo.UniqueUri, DeletionOptions.DeletePermanently); // EWS
                    Console.WriteLine("Message deleted...." + msgInfo.Subject);
                }
                else
                {
                    // Do something else
                }
            }
            // ExEnd:DeleteMessagesFromusingEWS
        }
    }
}