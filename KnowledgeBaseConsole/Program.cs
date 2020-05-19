using System;
using System.Collections.Generic;

namespace KnowledgeBaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            IList<Judgment> factors = program.GetInputFactors();

            Console.WriteLine("Входные параметры:");
            foreach (Judgment factor in factors)
                Console.WriteLine("\t {0}", factor.ToString());

            LogicalConclusion interpreter = new LogicalConclusion(factors);
            interpreter.FindLogicalConclusionAndSetLogicalOutput();

            foreach (KeyValuePair<Int32, IList<Judgment>> factorKeyValue in interpreter.LogicalOutput.FactorsOutput)
            {
                Console.WriteLine("Итерация №{0}", factorKeyValue.Key);
                foreach (Judgment factor in factorKeyValue.Value)
                    Console.WriteLine("\t{0}", factor);
            }
            //foreach (KeyValuePair<Int32, IList<Rule>> factorKeyValue in interpreter.RulesOutput)
            //{
            //    Console.WriteLine("Итерация №{0}", factorKeyValue.Key);
            //    foreach (Rule factor in factorKeyValue.Value)
            //        Console.WriteLine("\t{0}", factor);
            //}
        }

        #region Factors from Interface
        private IList<Judgment> GetInputFactors()
        {
            return new List<Judgment>
            {
                GetFactor1(),
                //GetFactor2(),
                GetFactor3(),
                GetFactor4(),
                GetFactor5(),
                GetFactor6(),
                GetFactor7(),
                //GetFactor8(),
                //GetFactor9(),
                //GetFactor10(),
                GetFactor11(),
                //GetFactor12(),
                //GetFactor13(),
            };
        }
        private Judgment GetFactor1()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.dt, FactorFuzzyValue.Successful);

            return judgment;
        }
        private Judgment GetFactor2()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.K2Ui, FactorFuzzyValue.Successful);

            return judgment;
        }
        private Judgment GetFactor3()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.KUn, FactorFuzzyValue.Nominal);

            return judgment;
        }
        private Judgment GetFactor4()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.Weather, FactorFuzzyValue.Successful);

            return judgment;
        }
        private Judgment GetFactor5()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.Ua, FactorFuzzyValue.Exceeding);

            return judgment;
        }
        private Judgment GetFactor6()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.Ub, FactorFuzzyValue.Nominal);

            return judgment;
        }
        private Judgment GetFactor7()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.Uc, FactorFuzzyValue.Nominal);

            return judgment;
        }
        private Judgment GetFactor8()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.Uimp, FactorFuzzyValue.Nominal);

            return judgment;
        }
        private Judgment GetFactor9()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.dUabc, FactorFuzzyValue.Nominal);

            return judgment;
        }
        private Judgment GetFactor10()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.KU, FactorFuzzyValue.Nominal);

            return judgment;
        }
        private Judgment GetFactor11()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.K2U, FactorFuzzyValue.Maximum);

            return judgment;
        }
        private Judgment GetFactor12()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.Uns, FactorFuzzyValue.Maximum);

            return judgment;
        }
        private Judgment GetFactor13()
        {
            Judgment judgment;

            judgment = new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Nominal);

            return judgment;
        }
        #endregion
    }
}
