using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecProj2.Utilities
{
    public class Hook : CommonDriver
    {
        
        [Before]
        public void setup()
        {
            Initialize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            //Thread.Sleep(1000);

        }
        [After]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
