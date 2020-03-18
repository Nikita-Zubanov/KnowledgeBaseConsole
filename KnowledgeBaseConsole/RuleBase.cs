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
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.OilInTank, EvaluationValue.Empty),
                new Antecedent(FactorName.OilInCan, EvaluationValue.Empty)
            });
            consequent = new Consequent(FactorName.OilInCan, EvaluationValue.AddOilInCan);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule2()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.OilInTank, EvaluationValue.Empty),
                new Antecedent(FactorName.OilInCan, EvaluationValue.NotEmpty)
            });
            consequent = new Consequent(FactorName.OilInTank, EvaluationValue.AddOilInTank);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule3()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.FuelInTank, EvaluationValue.Empty),
                new Antecedent(FactorName.FuelInCan, EvaluationValue.Empty)
            });
            consequent = new Consequent(FactorName.FuelInCan, EvaluationValue.AddFuelInCan);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule4()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.FuelInTank, EvaluationValue.Empty),
                new Antecedent(FactorName.FuelInCan, EvaluationValue.NotEmpty)
            });
            consequent = new Consequent(FactorName.FuelInTank, EvaluationValue.AddFuelInTank);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule5()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.ConnectedDevices, EvaluationValue.NotEmpty)
            });
            consequent = new Consequent(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule6()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.FlapPosition, EvaluationValue.Open)
            });
            consequent = new Consequent(FactorName.FlapPosition, EvaluationValue.CloseFlap);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule7()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.ConnectedDevices, EvaluationValue.DisconnectDevices)
            });
            consequent = new Consequent(FactorName.ConnectedDevices, EvaluationValue.Empty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule8()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.FlapPosition, EvaluationValue.CloseFlap)
            });
            consequent = new Consequent(FactorName.FlapPosition, EvaluationValue.Close);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule9()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.OilInCan, EvaluationValue.AddOilInCan)
            });
            consequent = new Consequent(FactorName.OilInCan, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule10()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.OilInTank, EvaluationValue.AddOilInTank)
            });
            consequent = new Consequent(FactorName.OilInTank, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule11()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.FuelInCan, EvaluationValue.AddFuelInCan)
            });
            consequent = new Consequent(FactorName.FuelInCan, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule12()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.FuelInTank, EvaluationValue.AddFuelInTank)
            });
            consequent = new Consequent(FactorName.FuelInTank, EvaluationValue.NotEmpty);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule13()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.OilInTank, EvaluationValue.NotEmpty),
                new Antecedent(FactorName.FuelInTank, EvaluationValue.NotEmpty),
                new Antecedent(FactorName.ConnectedDevices, EvaluationValue.Empty),
                new Antecedent(FactorName.FlapPosition, EvaluationValue.Close)
            });
            consequent = new Consequent(FactorName.Generator, EvaluationValue.Done);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule14()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.AmbientTemperature, EvaluationValue.Hight)
            });
            consequent = new Consequent(FactorName.Heater, EvaluationValue.SwitchOff);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule15()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.AmbientTemperature, EvaluationValue.Low)
            });
            consequent = new Consequent(FactorName.Heater, EvaluationValue.SwitchOn);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule16()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.Heater, EvaluationValue.SwitchOn),
            });
            consequent = new Consequent(FactorName.AmbientTemperature, EvaluationValue.Normal);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule17()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.Heater, EvaluationValue.SwitchOff),
            });
            consequent = new Consequent(FactorName.AmbientTemperature, EvaluationValue.Normal);

            return new SimpleRule(antecedent, consequent);
        }
        private Rule GetRule18()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent(new List<Judgment> {
                new Antecedent(FactorName.AmbientTemperature, EvaluationValue.Normal)
            });
            consequent = new Consequent(FactorName.Generator, EvaluationValue.CheckAmbientTemperature);

            return new SimpleRule(antecedent, consequent);
        }
        #endregion
    }
}
