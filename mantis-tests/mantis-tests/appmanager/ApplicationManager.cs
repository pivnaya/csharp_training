using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected RegistrationHelper registrationHelper;
        protected FtpHelper ftpHelper;
        protected JamesHelper jamesHelper;
        protected MailHelper mailHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.0/mantisbt-2.25.0/login_page.php";

            registrationHelper = new RegistrationHelper(this);
            ftpHelper = new FtpHelper(this);
            jamesHelper = new JamesHelper(this);
            mailHelper = new MailHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.0/mantisbt-2.25.0/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration
        {
            get
            {
                return registrationHelper;
            }
        }

        public FtpHelper Ftp
        {
            get
            {
                return ftpHelper;
            }
        }

        public JamesHelper James
        {
            get
            {
                return jamesHelper;
            }
        }

        public MailHelper Mail
        {
            get
            {
                return mailHelper;
            }
        }
    }
}
