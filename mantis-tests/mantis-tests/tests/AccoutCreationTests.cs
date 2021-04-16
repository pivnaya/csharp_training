using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccoutCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(Path.Combine(AppContext.BaseDirectory,"config_inc.php"), FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }

        [Test]
        public void TestAccoutRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "user",
                Password = "password",
                Email = "user@localhost.localdomain"
            };

            List<AccountData> accounts = app.admin.GetAllAccounts();
            AccountData existingAcount  = accounts.Find(x => x.Name == account.Name);
            
            if (existingAcount != null)
            {
                app.admin.DeleteAccount(existingAcount);
            }

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }
    }
}
