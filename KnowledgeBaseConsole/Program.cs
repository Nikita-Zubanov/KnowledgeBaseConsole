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
            Judgment judgment;

            judgment = new Judgment(FactorName.OilInTank, EvaluationValue.Empty);

            return judgment;
        }
        private Judgment GetFactor2()
        {
            Judgment judgment;

            judgment = new Judgment(FactorName.OilInCan, EvaluationValue.Empty);

            return judgment;
        }
        private Judgment GetFactor3()
        {
            Judgment judgment;

            judgment = new Judgment(FactorName.FuelInTank, EvaluationValue.Empty);

            return judgment;
        }
        private Judgment GetFactor4()
        {
            Judgment judgment;

            judgment = new Judgment(FactorName.FuelInCan, EvaluationValue.Empty);

            return judgment;
        }
        private Judgment GetFactor5()
        {
            Judgment judgment;

            judgment = new Judgment(FactorName.ConnectedDevices, EvaluationValue.NotEmpty);

            return judgment;
        }
        private Judgment GetFactor6()
        {
            Judgment judgment;

            judgment = new Judgment(FactorName.FlapPosition, EvaluationValue.Open);

            return judgment;
        }
        private Judgment GetFactor7()
        {
            Judgment judgment;

            judgment = new Judgment(FactorName.AmbientTemperature, EvaluationValue.Hight);

            return judgment;
        }
        #endregion
    }
}
