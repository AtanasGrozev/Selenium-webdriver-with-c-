﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIdeaCenter.Pages
{
    public class MyIdeasPage : BasePage
    {
        public MyIdeasPage(IWebDriver driver): base(driver)         
        {
                    
        }

        public string Url = BaseUrl + "/Ideas/MyIdeas";

        public void OpnePage()
        {
            driver.Navigate().GoToUrl(Url);   
        }

        public ReadOnlyCollection<IWebElement> AllIdeas => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

        public IWebElement ViewButtonLastIdea => AllIdeas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));
        public IWebElement EditButtonLastIdea => AllIdeas.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Edit')]"));
        public IWebElement DeleteButtonLastIdea => AllIdeas.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Delete')]"));
        public IWebElement DescriptionLastIdea => AllIdeas.Last().FindElement(By.XPath(".//p[@class='card-text']"));
        public IWebElement LastIdeaTiTle => AllIdeas.Last().FindElement(By.XPath(".//p[@class='card-text']"));

    }
}
