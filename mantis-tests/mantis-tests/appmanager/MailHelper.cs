﻿using OpaqueMail;
using System.Threading;

namespace mantis_tests
{
    public class MailHelper : HelperBase
    {
        public MailHelper(ApplicationManager manager) : base(manager) { }

        public string GetLastMail(AccountData account)
        {
            for (int i = 0; i < 20; i++)
            {
                Pop3Client pop3 = new Pop3Client("localhost", 110, account.Name, account.Password, false);
                pop3.Connect();
                pop3.Authenticate();
                int count = pop3.GetMessageCount();
                if (count > 0)
                {
                    MailMessage mail = pop3.GetMessage(1);
                    string body = mail.Body;
                    pop3.DeleteMessage(1);
                    return body;
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
            return null;
        }
    }
}
