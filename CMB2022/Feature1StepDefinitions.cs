using System;
using TechTalk.SpecFlow;

namespace CMB2022
{
    [Binding]
    public class Feature1StepDefinitions
    {
        [Given(@"\[context]")]
        public void GivenContext()
        {
            throw new PendingStepException();
        }

        [When(@"\[action]")]
        public void WhenAction()
        {
            throw new PendingStepException();
        }

        [Then(@"\[outcome]")]
        public void ThenOutcome()
        {
            throw new PendingStepException();
        }
    }
}
