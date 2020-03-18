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
                factor.Print();

            Interpreter interpreter = new Interpreter(factors);
            interpreter.SetLogicalOutput();

            foreach (KeyValuePair<Int32, IList<Judgment>> factorKeyValue in interpreter.FactorsOutput)
            {
                Console.WriteLine("Итерация №{0}", factorKeyValue.Key);
                foreach (Judgment factor in factorKeyValue.Value)
                    Console.WriteLine("\t{0}", factor);
            }
        }

        #region Factors from Interface
        private IList<Judgment> GetInputFactors()
        {
            return new List<Judgment>
            {
                GetFactor1(),
                GetFactor2(),
                GetFactor3(),
                GetFactor4(),
                GetFactor5(),
                GetFactor6(),
                GetFactor7()
            };
        }
        private Judgment GetFactor1()
        {
            Judgment antecedent;

            antecedent = new Antecedent(FactorName.OilInTank, EvaluationValue.Empty);

            return antecedent;
        }
        private Judgment GetFactor2()
        {
            Judgment antecedent;

            antecedent = new Antecedent(FactorName.OilInCan, EvaluationValue.Empty);

            return antecedent;
        }
        private Judgment GetFactor3()
        {
            Judgment antecedent;

            antecedent = new Antecedent(FactorName.FuelInTank, EvaluationValue.Empty);

            return antecedent;
        }
        private Judgment GetFactor4()
        {
            Judgment antecedent;

            antecedent = new Antecedent(FactorName.FuelInCan, EvaluationValue.Empty);

            return antecedent;
        }
        private Judgment GetFactor5()
        {
            Judgment antecedent;

            antecedent = new Antecedent(FactorName.ConnectedDevices, EvaluationValue.NotEmpty);

            return antecedent;
        }
        private Judgment GetFactor6()
        {
            Judgment antecedent;

            antecedent = new Antecedent(FactorName.FlapPosition, EvaluationValue.Open);

            return antecedent;
        }
        private Judgment GetFactor7()
        {
            Judgment antecedent;

            antecedent = new Antecedent(FactorName.AmbientTemperature, EvaluationValue.Hight);

            return antecedent;
        }
        #endregion
    }
}
