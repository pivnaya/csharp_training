using NUnit.Framework;
using System;
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
            Random rnd = new Random();
            int value = rnd.Next(0, 30);

            AccountData account = new AccountData()
            {
                Name = $"testuser{value}",
                Password = "password",
                Email = $"testuser{value}@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }
    }
}
