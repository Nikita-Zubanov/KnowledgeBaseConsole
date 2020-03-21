using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class RuleBase
    {
        //private IList<Rule> ruleList;
        private IList<Rule> ruleTree;

        //public IList<Rule> RuleList { get { return this.ruleList; } }
        public IList<Rule> RuleTree { get { return this.ruleTree; } }

        public RuleBase()
        {
            //this.ruleList = new List<Rule>();
            this.ruleTree = new List<Rule>();

            this.Initialize();
        }

        public void Verify(IVerification verification)
        {
            verification.Verify(this.ruleTree);
        }

        //public bool IsVerified(IVerification verification)
        //{
        //    return verification.IsVerified(this.ruleList);
        //}

        public IList<Judgment> GetTopRuleTreeConsequences()
        {
            IList<Judgment> topRulesConsequences = new List<Judgment>();

            foreach (Rule rule in this.ruleTree)
                topRulesConsequences.Add(rule.Consequent.Judgment);

            return topRulesConsequences;
        }

        private void Initialize()
        {
            this.UploadData();

            this.Verify(new Coherence());
            this.Verify(new Completeness());
        }

        private void UploadData()
        {
            //this.ruleList = this.GetKnowledgeBase();
            this.ruleTree = this.GetKnowledgeBase();
        }

        #region Rules from DataBase
        private IList<Rule> GetKnowledgeBase()
        {
            return new List<Rule>
            {
                GetRule1(),
                GetRule2(),
                GetRule3(),
                GetRule4(),
                GetRule5(),
                GetRule6(),
                GetRule7(),
                GetRule8(),
                GetRule9(),
                GetRule10(),
                GetRule11(),
                GetRule12(),
                GetRule13(),
                GetRule14(),
                GetRule15(),
                GetRule16(),
                GetRule17(),
                GetRule18(),
            };
        }
        private Rule GetRule1()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.Empty),
                new Judgment(FactorName.OilInCan, EvaluationValue.Empty)
            });
            consequent = new Consequent(new Judgment(FactorName.OilInCan, EvaluationValue.AddOilInCan));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule2()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.Empty),
                new Judgment(FactorName.OilInCan, EvaluationValue.NotEmpty)
            });
            consequent = new Consequent(new Judgment(FactorName.OilInTank, EvaluationValue.AddOilInTank));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule3()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Judgment(FactorName.FuelInTank, EvaluationValue.Empty),
                new Judgment(FactorName.FuelInCan, EvaluationValue.Empty)
            });
            consequent = new Consequent(new Judgment(FactorName.FuelInCan, EvaluationValue.AddFuelInCan));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule4()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Judgment(FactorName.FuelInTank, EvaluationValue.Empty),
                new Judgment(FactorName.FuelInCan, EvaluationValue.NotEmpty)
            });
            consequent = new Consequent(new Judgment(FactorName.FuelInTank, EvaluationValue.AddFuelInTank));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule5()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.ConnectedDevices, EvaluationValue.NotEmpty));
            consequent = new Consequent(new Judgment(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule6()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.FlapPosition, EvaluationValue.Open));
            consequent = new Consequent(new Judgment(FactorName.FlapPosition, EvaluationValue.CloseFlap));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule7()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices));
            consequent = new Consequent(new Judgment(FactorName.ConnectedDevices, EvaluationValue.Empty));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule8()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.FlapPosition, EvaluationValue.CloseFlap));
            consequent = new Consequent(new Judgment(FactorName.FlapPosition, EvaluationValue.Close));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule9()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.OilInCan, EvaluationValue.AddOilInCan));
            consequent = new Consequent(new Judgment(FactorName.OilInCan, EvaluationValue.NotEmpty));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule10()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.OilInTank, EvaluationValue.AddOilInTank));
            consequent = new Consequent(new Judgment(FactorName.OilInTank, EvaluationValue.NotEmpty));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule11()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.FuelInCan, EvaluationValue.AddFuelInCan));
            consequent = new Consequent(new Judgment(FactorName.FuelInCan, EvaluationValue.NotEmpty));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule12()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.FuelInTank, EvaluationValue.AddFuelInTank));
            consequent = new Consequent(new Judgment(FactorName.FuelInTank, EvaluationValue.NotEmpty));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule13()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.NotEmpty),
                new Judgment(FactorName.FuelInTank, EvaluationValue.NotEmpty),
                new Judgment(FactorName.ConnectedDevices, EvaluationValue.Empty),
                new Judgment(FactorName.FlapPosition, EvaluationValue.Close)
            });
            consequent = new Consequent(new Judgment(FactorName.Generator, EvaluationValue.Done));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule14()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Hight));
            consequent = new Consequent(new Judgment(FactorName.Heater, EvaluationValue.SwitchOff));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule15()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Low));
            consequent = new Consequent(new Judgment(FactorName.Heater, EvaluationValue.SwitchOn));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule16()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.Heater, EvaluationValue.SwitchOn));
            consequent = new Consequent(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule17()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.Heater, EvaluationValue.SwitchOff));
            consequent = new Consequent(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal));

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule18()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal));
            consequent = new Consequent(new Judgment(FactorName.Generator, EvaluationValue.CheckAmbientTemperature));

            return new SimpleRule(antecedent, consequent);
        }
        #endregion
    }
}
