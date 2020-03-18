using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class RuleBase
    {
        private IList<Rule> rules;
        private IList<Rule> compoundRules;

        public IList<Rule> Rules { get { return this.rules; } }
        public IList<Rule> CompoundRules { get { return this.compoundRules; } }

        public RuleBase()
        {
            this.rules = new List<Rule>();
            this.compoundRules = new List<Rule>();

            this.Initialize();
        }

        public void Verify(IVerification verification)
        {
            verification.Verify(this.compoundRules);
        }

        private void Initialize()
        {
            this.UploadData();

            this.Verify(new Completeness());
        }

        private void UploadData()
        {
            this.rules = this.GetKnowledgeBase();
            this.compoundRules = this.GetKnowledgeBase();
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
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.Empty),
                new Judgment(FactorName.OilInCan, EvaluationValue.Empty)
            });
            consequent = new Judgment(FactorName.OilInCan, EvaluationValue.AddOilInCan);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule2()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.Empty),
                new Judgment(FactorName.OilInCan, EvaluationValue.NotEmpty)
            });
            consequent = new Judgment(FactorName.OilInTank, EvaluationValue.AddOilInTank);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule3()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new List<Judgment> {
                new Judgment(FactorName.FuelInTank, EvaluationValue.Empty),
                new Judgment(FactorName.FuelInCan, EvaluationValue.Empty)
            });
            consequent = new Judgment(FactorName.FuelInCan, EvaluationValue.AddFuelInCan);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule4()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new List<Judgment> {
                new Judgment(FactorName.FuelInTank, EvaluationValue.Empty),
                new Judgment(FactorName.FuelInCan, EvaluationValue.NotEmpty)
            });
            consequent = new Judgment(FactorName.FuelInTank, EvaluationValue.AddFuelInTank);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule5()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.ConnectedDevices, EvaluationValue.NotEmpty));
            consequent = new Judgment(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule6()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.FlapPosition, EvaluationValue.Open));
            consequent = new Judgment(FactorName.FlapPosition, EvaluationValue.CloseFlap);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule7()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices));
            consequent = new Judgment(FactorName.ConnectedDevices, EvaluationValue.Empty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule8()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.FlapPosition, EvaluationValue.CloseFlap));
            consequent = new Judgment(FactorName.FlapPosition, EvaluationValue.Close);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule9()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.OilInCan, EvaluationValue.AddOilInCan));
            consequent = new Judgment(FactorName.OilInCan, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule10()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.OilInTank, EvaluationValue.AddOilInTank));
            consequent = new Judgment(FactorName.OilInTank, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule11()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.FuelInCan, EvaluationValue.AddFuelInCan));
            consequent = new Judgment(FactorName.FuelInCan, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule12()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.FuelInTank, EvaluationValue.AddFuelInTank));
            consequent = new Judgment(FactorName.FuelInTank, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule13()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new List<Judgment> {
                new Judgment(FactorName.OilInTank, EvaluationValue.NotEmpty),
                new Judgment(FactorName.FuelInTank, EvaluationValue.NotEmpty),
                new Judgment(FactorName.ConnectedDevices, EvaluationValue.Empty),
                new Judgment(FactorName.FlapPosition, EvaluationValue.Close)
            });
            consequent = new Judgment(FactorName.Generator, EvaluationValue.Done);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule14()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Hight));
            consequent = new Judgment(FactorName.Heater, EvaluationValue.SwitchOff);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule15()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Low));
            consequent = new Judgment(FactorName.Heater, EvaluationValue.SwitchOn);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule16()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.Heater, EvaluationValue.SwitchOn));
            consequent = new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule17()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.Heater, EvaluationValue.SwitchOff));
            consequent = new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule18()
        {
            JudgmentList antecedent;
            Judgment consequent;

            antecedent = new JudgmentList(new Judgment(FactorName.AmbientTemperature, EvaluationValue.Normal));
            consequent = new Judgment(FactorName.Generator, EvaluationValue.CheckAmbientTemperature);

            return new SimpleRule(antecedent, consequent);
        }
        #endregion
    }
}
