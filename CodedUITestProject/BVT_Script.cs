using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace BVT_Script
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class BVT_Script
    {
        public void RD()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Users\\abhishek-k-verma\\Desktop\\RDP.bat";
            proc.StartInfo.RedirectStandardError = false;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.WaitForExit();
        }

        //[TestMethod] public void BVT()
        //{

        //    BrowserWindow browser = BrowserWindow.Launch("http://gbmqa.mercer.com");
        //    HtmlButton btn = new HtmlButton(browser);
        //    HtmlEdit UName = new HtmlEdit(browser);
        //    HtmlEdit pass = new HtmlEdit(browser);


        //    UName.SearchProperties.Add("Id", "Login_login_GBMDefault_txtUsername", PropertyExpressionOperator.Contains);
        //    pass.SearchProperties.Add("Id", "Login_login_GBMDefault_txtPassword", PropertyExpressionOperator.Contains);
        //    btn.SearchProperties.Add("Id", "Login_login_GBMDefault_cmdLogin", PropertyExpressionOperator.Contains);
        //    btn.SearchProperties.Add("TagName", "INPUT", PropertyExpressionOperator.Contains);

        //    Keyboard.SendKeys(UName, "abhishek-k-verma");
        //    Keyboard.SendKeys(pass, "Welcome1");
        //    Mouse.Click(btn);
        //    Playback.Wait(15000);
        //}


        [TestMethod]
       
        public void LocalAppLoginTest()

        {

           // RD();
            BrowserWindow browser = BrowserWindow.Launch("http://usdfw14ws60v/Login.aspx");
            HtmlEdit uname = new HtmlEdit(browser);
            HtmlEdit pass = new HtmlEdit(browser);
            HtmlButton loginbtn = new HtmlButton(browser);


            uname.SearchProperties.Add("Id", "TextBox1");
            pass.SearchProperties.Add("Id", "TextBox2");

            loginbtn.SearchProperties.Add("Id", "Button1");
            loginbtn.SearchProperties.Add("TagName", "INPUT");


            Keyboard.SendKeys(uname, "testname");
            Keyboard.SendKeys(pass, "testpass");

            Mouse.Click(loginbtn);

            HtmlSpan labelHome = new HtmlSpan(browser);
            labelHome.SearchProperties.Add("InnerText", "Welcome");

            //labelHome.WaitForControlExist(45000);
            //HtmlButton close = new HtmlButton(browser);
            //close.SearchProperties.Add("FriendlyName", "Close");

            //Mouse.Click(close);
        }

        [TestMethod]
        public void LocalAppLoginValidation()
        {
            BrowserWindow browser = BrowserWindow.Launch("http://usdfw14ws60v/Login.aspx");
            HtmlEdit uname = new HtmlEdit(browser);
            HtmlEdit pass = new HtmlEdit(browser);
            HtmlButton loginbtn = new HtmlButton(browser);


            uname.SearchProperties.Add("Id", "TextBox1");
            pass.SearchProperties.Add("Id", "TextBox2");

            loginbtn.SearchProperties.Add("Id", "Button1");
            loginbtn.SearchProperties.Add("TagName", "INPUT");


            //Keyboard.SendKeys(uname, "testname");
            //Keyboard.SendKeys(pass, "testpass");

            Mouse.Click(loginbtn);
            Playback.Wait(5000);
            if (uname.WaitForControlExist())
                Console.WriteLine("Missing username and Password");
            else
            {
                Console.WriteLine("User logged in even with Missing username and Password");
                Assert.Fail("Test failed");
            }

        }



    }
}
