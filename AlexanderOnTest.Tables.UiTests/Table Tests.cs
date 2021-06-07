using System;
using AlexanderOnTest.NetCoreWebDriverFactory;
using AlexanderOnTest.NetCoreWebDriverFactory.Config;
using AlexanderOnTest.NetCoreWebDriverFactory.WebDriverFactory;
using AlexanderOnTest.NetCoreWebDriverFactory.DependencyInjection;
using AlexanderOnTest.NetCoreWebDriverFactory.Utils.Builders;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AlexanderOnTest.Tables.UiTests
{
    public class TableTests
    {
        private IWebDriverFactory WebDriverFactory { get; set; }
        private IWebDriver webDriver;
        private readonly IWebDriverConfiguration _webDriverConfiguration;

        public TableTests()
        {
            _webDriverConfiguration = WebDriverConfigurationBuilder.Start()
                .WithBrowser(Browser.Firefox)
                .WithIsLocal(true)
                .WithWindowSize(WindowSize.Hd)
                .Build();
        }
        
        [SetUp]
        public void Setup()
        {
            IServiceCollection serviceCollection = ServiceCollectionFactory.GetDefaultServiceCollection(false, _webDriverConfiguration);

            IServiceProvider desktopServiceProvider = serviceCollection.BuildServiceProvider();

            WebDriverFactory = desktopServiceProvider.GetService<IWebDriverFactory>();
        }

        [Test]
        public void Test1()
        {
            webDriver = WebDriverFactory.GetWebDriver(_webDriverConfiguration);

            webDriver.Url = "http://localhost:8080/";

            webDriver.Title.Should().Be("Automating tables");
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                webDriver.Quit();
            }
        }
        
        
        [OneTimeTearDown]
        public void Teardown()
        {
            webDriver.Quit();
        }
    }
}