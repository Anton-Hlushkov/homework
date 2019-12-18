﻿using System.Collections.Generic;
using CalculatorTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Test
{
    class TestInvoker//class containing the implementation of interaction with the site for unit tests
    {

        CalculatorPage calculatorPage;
        public TestInvoker(CalculatorPage calkulyatorRuPage)
        {
            this.calculatorPage = calkulyatorRuPage;
        }



        public  string GetResult(string buttonSequence)//method for interaction with buttons, which names contains in input string, returns desplaying result
        {
            List<string> webElementsNameSequence = ParseStringToButtonName(buttonSequence);

            if (buttonSequence.Contains("/0"))
            {
                foreach (char symbol in buttonSequence)
                {
                    calculatorPage.WebElements[symbol.ToString()].Click();
                }

            }

            foreach (string buttonName in webElementsNameSequence)
            {
                calculatorPage.WebElements[buttonName].Click();
            }

            string result = calculatorPage.WebElements["Display"].Text;

            calculatorPage.WebElements["AC"].Click();
            return result.Replace(" ", "");
        }

        static List<string> ParseStringToButtonName(string buttonSequence)
        {
            List<string> webElementsNameSequence = new List<string>();

            for (int i = 0; i < buttonSequence.Length; i++)
            {
                if (buttonSequence[i] == 'M' && buttonSequence[i + 1] == '-')
                {
                    webElementsNameSequence.Add("M-");
                    i++;
                }
                else if (buttonSequence[i] == 'M' && buttonSequence[i + 1] == '+')
                {
                    webElementsNameSequence.Add("M+");
                    i++;
                }
                else if (buttonSequence[i] == 'M' && buttonSequence[i + 1] == 'R')
                {
                    webElementsNameSequence.Add("MR");
                    i++;
                }
                else if (buttonSequence[i] == 'M' && buttonSequence[i + 1] == 'C')
                {
                    webElementsNameSequence.Add("MC");
                    i++;
                }
                else if (buttonSequence[i] == 'D' && buttonSequence[i + 1] == 'E' && buttonSequence[i + 2] == 'L')
                {
                    webElementsNameSequence.Add("DEL");
                    i += 2;
                }
                else if (buttonSequence[i] == '(' && buttonSequence[i + 1] == '-' && buttonSequence[i + 2] == ')')
                {
                    webElementsNameSequence.Add("(-)");
                    i += 2;
                }
                else if (buttonSequence[i] == 'A' && buttonSequence[i + 1] == 'C')
                {
                    webElementsNameSequence.Add("AC");
                    i++;
                }
                else if (buttonSequence[i] == '0' && buttonSequence[i + 1] == '0')
                {
                    webElementsNameSequence.Add("00");
                    i++;
                }
                else
                {
                    webElementsNameSequence.Add(buttonSequence[i].ToString());
                }
            }

            return webElementsNameSequence;
        }
    }
}