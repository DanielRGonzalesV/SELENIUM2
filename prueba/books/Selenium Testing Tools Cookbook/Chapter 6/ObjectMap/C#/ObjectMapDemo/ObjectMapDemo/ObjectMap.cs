using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using OpenQA.Selenium;

namespace BMICalculator
{
    class ObjectMap
    {
        protected XElement _root;
    
        public ObjectMap(string objectMapFile)
        {
            try
            {
                string fileToLoad = objectMapFile;
                _root = XElement.Load(fileToLoad);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Unable to locate Object Map File, check if file exists on given path");
            }
        }

        public By GetLocator(string locatorName)
        {
            var element = from elements in _root.Elements("element")
                          where elements.Attributes("name").First().Value == locatorName
                          select elements;
            try
            {
                string locatorType = element.Attributes("locator_type").First().Value.ToString();
                string locatorValue = element.Attributes("locator_value").First().Value.ToString();

                switch (locatorType.ToLower())
                {
                    case "id":
                        return By.Id(locatorValue);
                    case "name":
                        return By.Name(locatorValue);
                    case "classname":
                        return By.ClassName(locatorValue);
                    case "linktext":
                        return By.LinkText(locatorValue);
                    case "partiallinktext":
                        return By.PartialLinkText(locatorValue);
                    case "css":
                        return By.CssSelector(locatorValue);
                    case "xpath":
                        return By.XPath(locatorValue);
                    case "tagname":
                        return By.TagName(locatorValue);
                    default:
                        throw new Exception("Locator Type '" + locatorType + "' not supported!!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Failed to generate locator for '" + locatorName + "'");
            }
        }
    }
}
