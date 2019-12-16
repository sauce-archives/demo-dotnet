using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium3.MsTest.Scripts.Emusim
{
    [TestClass]
    [TestCategory("MsTest")]
    [TestCategory("Emusim")]
    [TestCategory("Android")]

    public class Emusim
    {
        [TestMethod]
        public void Android71()
        {
            /*
             * Best Practice
             * Instead of using hardcoded username and access key, you should store
             * the credentials in environment variables on your system. Not sure how to do this?
             * This document will help:
             * https://wiki.saucelabs.com/display/DOCS/Best+Practice%3A+Use+Environment+Variables+for+Authentication+Credentials
             */
            var sauceUserName =
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey =
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            /*
             * In this section, we will configure our test to run on some specific
             * browser/os combination in Sauce Labs
             */
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("username", sauceUserName);
            capabilities.SetCapability("accessKey", sauceAccessKey);
            capabilities.SetCapability("appiumVersion", "1.9.1");
            capabilities.SetCapability("deviceName", "Samsung Galaxy Tab A 10 GoogleAPI Emulator");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("browserName", "Chrome");
            capabilities.SetCapability("platformVersion", "7.1");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("name", MethodBase.GetCurrentMethod().Name);
            capabilities.SetCapability("newCommandTimeout", 90);

            var driver = new AndroidDriver<IWebElement>(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities);
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Assert.IsTrue(true);
            driver.Quit();
        }
    }
}
