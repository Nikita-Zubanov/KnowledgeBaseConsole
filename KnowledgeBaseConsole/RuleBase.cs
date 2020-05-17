using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class RuleBase
    {
        private IList<Rule> ruleList;
        private IList<Rule> ruleTree;

        public IList<Rule> RuleTree { get { return this.ruleTree; } }

        public RuleBase()
        {
            this.ruleList = new List<Rule>();
            this.ruleTree = new List<Rule>();

            this.Initialize();
        }

        //public bool AddRule(Rule rule)
        //{
        //    if (this.IsVerified(new Coherence))
        //    {
        //        this.ruleList.Add(rule);

        //        return true;
        //    }
        //    else
        //        throw new Exception(
        //            "Введенное вами правило противоречит правилам в базе знаний: \n" +
        //            "\t у одного антецедента есть лишь один консеквент, т.е. у одного условия не может быть несколько выводов");
        //}

        public IList<Judgment> GetTopRuleTreeConsequences()
        {
            IList<Judgment> topRulesConsequences = new List<Judgment>();

            foreach (Rule rule in this.ruleTree)
                topRulesConsequences.Add(rule.Consequent);

            return topRulesConsequences;
        }

        private void Initialize()
        {
            this.UploadData();

            this.Transform(new Coherence());
            this.Transform(new Completeness());
        }

        private void Transform(ITransformer verification)
        {
            verification.Transform(this.ruleTree);
        }

        private bool IsVerified(IVerification verification)
        {
            return verification.IsVerified(this.ruleList);
        }

        private void UploadData()
        {
            this.ruleList = this.GetKnowledgeBase();
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
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.Empty),
                new Judgment(FactorName.OilInCan, EvaluationValue.Empty)
            };
            consequent = new Judgment(FactorName.OilInCan, EvaluationValue.AddOilInCan);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule2()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.Empty),
                new Judgment(FactorName.OilInCan, EvaluationValue.NotEmpty)
            };
            consequent = new Judgment(FactorName.OilInTank, EvaluationValue.AddOilInTank);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule3()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> {
                new Judgment(FactorName.FuelInTank, EvaluationValue.Empty),
                new Judgment(FactorName.FuelInCan, EvaluationValue.Empty)
            };
            consequent = new Judgment(FactorName.FuelInCan, EvaluationValue.AddFuelInCan);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule4()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> {
                new Judgment(FactorName.FuelInTank, EvaluationValue.Empty),
                new Judgment(FactorName.FuelInCan, EvaluationValue.NotEmpty)
            };
            consequent = new Judgment(FactorName.FuelInTank, EvaluationValue.AddFuelInTank);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule5()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.ConnectedDevices, EvaluationValue.NotEmpty) };
            consequent = new Judgment(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule6()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.FlapPosition, EvaluationValue.Open) };
            consequent = new Judgment(FactorName.FlapPosition, EvaluationValue.CloseFlap);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule7()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices) };
            consequent = new Judgment(FactorName.ConnectedDevices, EvaluationValue.Empty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule8()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.FlapPosition, EvaluationValue.CloseFlap) };
            consequent = new Judgment(FactorName.FlapPosition, EvaluationValue.Close);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule9()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.OilInCan, EvaluationValue.AddOilInCan) };
            consequent = new Judgment(FactorName.OilInCan, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule10()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.OilInTank, EvaluationValue.AddOilInTank) };
            consequent = new Judgment(FactorName.OilInTank, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule11()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.FuelInCan, EvaluationValue.AddFuelInCan) };
            consequent = new Judgment(FactorName.FuelInCan, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule12()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.FuelInTank, EvaluationValue.AddFuelInTank) };
            consequent = new Judgment(FactorName.FuelInTank, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule13()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.NotEmpty),
                new Judgment(FactorName.FuelInTank, EvaluationValue.NotEmpty),
                new Judgment(FactorName.ConnectedDevices, EvaluationValue.Empty),
                new Judgment(FactorName.FlapPosition, EvaluationValue.Close)
            };
            consequent = new Judgment(FactorName.Generator, EvaluationValue.Done);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule14()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.AmbientTemperature, EvaluationValue.Hight) };
            consequent = new Judgment(FactorName.Heater, EvaluationValue.SwitchOff);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule15()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.AmbientTemperature, EvaluationValue.Low) };
            consequent = new Judgment(FactorName.Heater, EvaluationValue.SwitchOn);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule16()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.Heater, EvaluationValue.SwitchOn) };
            consequent = new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule17()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.Heater, EvaluationValue.SwitchOff) };
            consequent = new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule18()
        {
            IList<Judgment> antecedent;
            Judgment consequent;

            antecedent = new List<Judgment> { new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal) };
            consequent = new Judgment(FactorName.Generator, EvaluationValue.CheckAmbientTemperature);

            return new SimpleRule(antecedent, consequent);
        }
        #endregion
    }
}