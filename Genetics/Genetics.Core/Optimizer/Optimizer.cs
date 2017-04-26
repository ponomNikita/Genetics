using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics.Core.Optimizer
{
    public class Optimizer : GeneticAlgorithm
    {
        private readonly Func<double, double> _function;
        private readonly double _rangeA;
        private readonly double _rangeB;
        private readonly int _iterationCount;
        private int _iterationNumber;
        private int _populationSize;

        public Optimizer(Func<double, double> function, double rangeA, double rangeB, int iterationCount, int populationSize)
        {
            _function = function;
            _rangeA = rangeA;
            _rangeB = rangeB;
            _iterationCount = iterationCount;
            _populationSize = populationSize;
        }

        public override ISolution Solve()
        {
            _iterationNumber = 0;

            return base.Solve();
        }

        protected override bool IsSolved()
        {
            return _iterationCount <= _iterationNumber++;
        }

        protected override Population GeneratePopulation()
        {
            List<ISolution> solutions = new List<ISolution>();
            for (int i = 0; i < _populationSize; i++)
            {
                OptimizedSolution solution = new OptimizedSolution(_function, _rangeA, _rangeB);
                solutions.Add(solution);
            }

            return new OptimizedSolutionsPopulation(solutions);
        }
    }
}
