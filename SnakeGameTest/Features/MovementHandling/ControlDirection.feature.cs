﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SnakeGameTest.Features.MovementHandling
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ControlDirectionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ControlDirection.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/MovementHandling", "ControlDirection", "The player can control the direction of the snake.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ControlDirection")))
            {
                global::SnakeGameTest.Features.MovementHandling.ControlDirectionFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void ControlDirection(string direction, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("direction", direction);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ControlDirection", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 testRunner.Given("the game is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "direction"});
                table3.AddRow(new string[] {
                            string.Format("{0}", direction)});
#line 6
 testRunner.When("a new direction is detected", ((string)(null)), table3, "When ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "direction"});
                table4.AddRow(new string[] {
                            string.Format("{0}", direction)});
#line 9
 testRunner.Then("update the direction of snake to the new direction", ((string)(null)), table4, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ControlDirection: UP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ControlDirection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "UP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:direction", "UP")]
        public virtual void ControlDirection_UP()
        {
#line 4
this.ControlDirection("UP", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ControlDirection: DOWN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ControlDirection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "DOWN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:direction", "DOWN")]
        public virtual void ControlDirection_DOWN()
        {
#line 4
this.ControlDirection("DOWN", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ControlDirection: LEFT")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ControlDirection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "LEFT")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:direction", "LEFT")]
        public virtual void ControlDirection_LEFT()
        {
#line 4
this.ControlDirection("LEFT", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ControlDirection: RIGHT")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ControlDirection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "RIGHT")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:direction", "RIGHT")]
        public virtual void ControlDirection_RIGHT()
        {
#line 4
this.ControlDirection("RIGHT", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
