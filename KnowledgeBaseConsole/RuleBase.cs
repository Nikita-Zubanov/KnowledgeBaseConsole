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
                GetRule01(),
                GetRule02(),
                GetRule03(),
                GetRule11(),
                GetRule12(),
                GetRule13(),
                GetRule14(),
                GetRule21(),
                GetRule22(),
                GetRule23(),
                GetRule31(),
                GetRule32(),
                GetRule33(),
                GetRule41(),
                GetRule42(),
                GetRule51(),
                GetRule52(),
                GetRule53(),
            };
        }

        #region Uimp
        private Rule GetRule11()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Exceeding))
                .AND(new Judgment(FactorTitle.Weather, FactorFuzzyValue.Unsuccessful));
            consequent = new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Exceeding);
            other = new Judgment(FactorTitle.Uimp, FactorFuzzyValue.NotExceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule12()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Maximum))
                .AND(new Judgment(FactorTitle.Uimp, FactorFuzzyValue.NotExceeding))
                .AND(new Judgment(FactorTitle.Weather, FactorFuzzyValue.Unsuccessful));
            consequent = new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Maximum);
            other = new Judgment(FactorTitle.Uimp, FactorFuzzyValue.NotMaximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule13()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new Judgment(FactorTitle.Uimp, FactorFuzzyValue.NotExceeding))
                .AND(new Judgment(FactorTitle.Uimp, FactorFuzzyValue.NotMaximum))
                .AND(new Judgment(FactorTitle.Weather, FactorFuzzyValue.Unsuccessful));
            consequent = new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule14()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .AND(new Judgment(FactorTitle.Weather, FactorFuzzyValue.Successful));
            consequent = new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion

        #region dUabc
        private Rule GetRule21()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Exceeding));
            consequent = new Judgment(FactorTitle.dUabc, FactorFuzzyValue.Exceeding);
            other = new Judgment(FactorTitle.dUabc, FactorFuzzyValue.NotExceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.dUabc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule22()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Maximum))
                .AND(new Judgment(FactorTitle.dUabc, FactorFuzzyValue.NotExceeding));
            consequent = new Judgment(FactorTitle.dUabc, FactorFuzzyValue.Maximum);
            other = new Judgment(FactorTitle.dUabc, FactorFuzzyValue.NotMaximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.dUabc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule23()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new Judgment(FactorTitle.dUabc, FactorFuzzyValue.NotExceeding))
                .AND(new Judgment(FactorTitle.dUabc, FactorFuzzyValue.NotMaximum));
            consequent = new Judgment(FactorTitle.dUabc, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.dUabc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion

        #region KU
        private Rule GetRule31()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Exceeding));
            consequent = new Judgment(FactorTitle.KU, FactorFuzzyValue.Exceeding);
            other = new Judgment(FactorTitle.KU, FactorFuzzyValue.NotExceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule32()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Maximum))
                .AND(new Judgment(FactorTitle.KU, FactorFuzzyValue.NotExceeding));
            consequent = new Judgment(FactorTitle.KU, FactorFuzzyValue.Maximum);
            other = new Judgment(FactorTitle.KU, FactorFuzzyValue.NotMaximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule33()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Ua, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.Ub, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new Judgment(FactorTitle.KU, FactorFuzzyValue.NotExceeding))
                .AND(new Judgment(FactorTitle.KU, FactorFuzzyValue.NotMaximum));
            consequent = new Judgment(FactorTitle.KU, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion

        #region K2Ui
        private Rule GetRule41()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .AND(new Judgment(FactorTitle.K2U, FactorFuzzyValue.Nominal));
            consequent = new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Successful);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.K2Ui, FactorFuzzyValue.Successful, FactorFuzzyValue.Unsuccessful);
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule42()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.K2U, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.K2U, FactorFuzzyValue.Maximum));
            consequent = new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Unsuccessful);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.K2Ui, FactorFuzzyValue.Successful, FactorFuzzyValue.Unsuccessful); 
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion

        #region Uns
        private Rule GetRule51()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.KU, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.KUn, FactorFuzzyValue.Exceeding));
            consequent = new Judgment(FactorTitle.Uns, FactorFuzzyValue.Exceeding);
            other = new Judgment(FactorTitle.Uns, FactorFuzzyValue.NotExceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uns, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule52()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.KU, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.KUn, FactorFuzzyValue.Maximum))
                .AND(new Judgment(FactorTitle.Uns, FactorFuzzyValue.NotExceeding));
            consequent = new Judgment(FactorTitle.Uns, FactorFuzzyValue.Maximum);
            other = new Judgment(FactorTitle.Uns, FactorFuzzyValue.NotMaximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uns, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule53()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.KU, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.KUn, FactorFuzzyValue.Nominal))
                .AND(new Judgment(FactorTitle.Uns, FactorFuzzyValue.NotExceeding))
                .AND(new Judgment(FactorTitle.Uns, FactorFuzzyValue.NotMaximum));
            consequent = new Judgment(FactorTitle.Uns, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uns, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion

        #region ServiceabilityEquipment
        private Rule GetRule01()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.dUabc, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.Uns, FactorFuzzyValue.Exceeding), new Judgment(FactorTitle.K2U, FactorFuzzyValue.Exceeding))
                .OR(new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Successful), new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Unsuccessful))
                .OR(new Judgment(FactorTitle.dt, FactorFuzzyValue.Successful), new Judgment(FactorTitle.dt, FactorFuzzyValue.Unsuccessful));
            consequent = new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Exceeding);
            other = new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.NotExceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule02()
        {
            Antecedent antecedent;
            Judgment consequent;
            Judgment other;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.dUabc, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.Uns, FactorFuzzyValue.Maximum), new Judgment(FactorTitle.K2U, FactorFuzzyValue.Maximum))
                .OR(new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Successful), new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Unsuccessful))
                .OR(new Judgment(FactorTitle.dt, FactorFuzzyValue.Successful), new Judgment(FactorTitle.dt, FactorFuzzyValue.Unsuccessful))
                .AND(new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.NotExceeding));
            consequent = new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Maximum);
            other = new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.NotMaximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent, other);
        }
        private Rule GetRule03()
        {
            Antecedent antecedent;
            Judgment consequent;

            antecedent = new Antecedent()
                .OR(new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.dUabc, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.Uns, FactorFuzzyValue.Nominal), new Judgment(FactorTitle.K2U, FactorFuzzyValue.Nominal))
                .AND(new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Successful))
                .AND(new Judgment(FactorTitle.dt, FactorFuzzyValue.Successful))
                .AND(new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.NotExceeding))
                .AND(new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.NotMaximum));
            consequent = new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);
            return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion
        #endregion
    }
}
/*
        #region Uimp
        private Rule GetRule111()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule112()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule113()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }private Rule GetRule121()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule122()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule123()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule131()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule132()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule133()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Presence));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule14()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Weather, FactorFuzzyValue.Miss));

            consequent = new Consequent(FactorTitle.Uimp, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion
        #region dUabc
        private Rule GetRule211()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule212()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule213()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule221()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule222()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule223()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule231()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule232()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule233()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.dUabc, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion
        #region KU
        private Rule GetRule311()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule312()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule313()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule321()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule322()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule323()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule331()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule332()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule333()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uc, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ub, FactorFuzzyValue.Nominal))
                .AND(new LinguisticVariable(FactorTitle.Ua, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.KU, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion
        #region K2Ui
        private Rule GetRule41()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.K2U, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.K2Ui, FactorFuzzyValue.Miss);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule42()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .ORInAND(new LinguisticVariable(FactorTitle.K2U, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum));

            consequent = new Consequent(FactorTitle.K2Ui, FactorFuzzyValue.Presence);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion
        #region Uns
        private Rule GetRule511()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.KUn, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.Uns, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule512()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.KUn, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.Uns, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule513()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.KUn, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.Uns, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule521()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.KUn, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.Uns, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule522()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.KUn, FactorFuzzyValue.Maximum))
                .ORInAND(new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.Uns, FactorFuzzyValue.Maximum);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        private Rule GetRule523()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.KUn, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.KU, FactorFuzzyValue.Nominal));

            consequent = new Consequent(FactorTitle.Uns, FactorFuzzyValue.Nominal);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion
        #region ServiceabilityEquipment
        private Rule GetRule611()
        {
            Antecedent antecedent;
            Consequent consequent;

            antecedent = new Antecedent()
                .AND(new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding))
                .ORInAND(new LinguisticVariable(FactorTitle.dUabc, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.Uns, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.KUn, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.K2Ui, FactorFuzzyValue.Presence, FactorFuzzyValue.Miss))
                .ORInAND(new LinguisticVariable(FactorTitle.K2U, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal))
                .ORInAND(new LinguisticVariable(FactorTitle.dt, FactorFuzzyValue.Presence, FactorFuzzyValue.Miss));

            consequent = new Consequent(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Exceeding);

            LinguisticVariable linguisticVariable = new LinguisticVariable(FactorTitle.Uimp, FactorFuzzyValue.Exceeding, FactorFuzzyValue.Maximum, FactorFuzzyValue.Nominal);return new SimpleRule(linguisticVariable, antecedent, consequent);
        }
        #endregion */