using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Mars.Utilities
{
    public class Driver
    {
        protected readonly IWebDriver driver;

        public Driver()
        {
            driver = new ChromeDriver();
        }
    }
}
