using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Diagnostics;

namespace variant.specs
{
    [Binding]
    public class Steps
    {
        private string output;
        private Process process = new Process();

        [Given(@"Joe has logged in")]
        public void GivenIHaveRunTheApplication()
        {
            var customer = Environment.GetEnvironmentVariable("customer");

            process.StartInfo.FileName = @"c:\Code\variant\build\build\variant.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;

            process.StartInfo.Arguments = "-c " + customer;
        }

        [Given(@"I ask to set the next audit date")]
        public void GivenIAskToSetTheNextAuditDate()
        {
            process.StartInfo.Arguments += " -d";
        }


        [Given(@"Joe navigates to the welcome page")]
        public void WhenIRunTheApplication()
        {
            process.Start();

            output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
        }

        [When(@"foo")]
        public void WhenFoo()
        {
            process.Start();

            output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
        }

        [When(@"Joe navigates to the catalog page")]
        public void WhenNavigatesToTheCatalogPage()
        {
            process.StartInfo.Arguments += " -d";
        }

        [When(@"Joe adds something to the shopping cart")]
        public void WhenAddsSomethingToTheShoppingCart()
        {
            throw new Exception();
        }

        
        [Then(@"Joe should see the welcome message ""(.*)""")]
        public void ThenIShouldSeeTheWelcomeMessage(string welcomeMessage)
        {
            output.Should().Contain(welcomeMessage);
        }

        [Then(@"the next audit date should be set")]
        public void ThenTheNextAuditDateShouldBeSet()
        {
            output.Should().Contain("Next Audit Date Set");
        }

        [Given(@"I have asked to send a change request email")]
        public void GivenIHaveAskedToSendAChangeRequestEmail()
        {
            process.StartInfo.Arguments += " -r";
        }

        [Then(@"a change request email should be sent")]
        public void ThenAChangeRequestEmailShouldBeSent()
        {
            output.Should().Contain("Change Request Email Sent");
        }

        [Then(@"Joe should see the list of available items")]
        public void ThenShouldSeeListOfAvailableItems()
        {
            output.Should().Contain("Available Items");
        }
    }
}
