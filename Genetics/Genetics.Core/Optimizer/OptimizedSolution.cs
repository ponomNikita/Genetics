using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics.Core.Optimizer
{
    public class OptimizedSolution : ISolution
    {
        private readonly Func<double, double> _function;
        private readonly double _rangeA;
        private readonly double _rangeB;

        private double _solution;

        public OptimizedSolution(Func<double, double> function, double rangeA, double rangeB)
        {
            if (rangeA >= rangeB)
                throw new ArgumentException();

            _function = function;
            _rangeA = rangeA;
            _rangeB = rangeB;

            GenerateSolution();
        }

        public ISolution Mutate()
        {
            Random random = new Random();
            double solution =  random.NextDouble() * (_rangeB - _rangeA) + _rangeA;

            var copy = this.Copy();
            copy.SetSolution(solution);

            return copy;
        }

        private void GenerateSolution()
        {
            Random random = new Random();
            double solution = random.NextDouble() * (_rangeB - _rangeA) + _rangeA;

            SetSolution(solution);
        }

        public double GetSolution()
        {
            return _solution;
        }

        public void SetSolution(double value)
        {
            _solution = value;
        }

        public OptimizedSolution Copy()
        {
            return new OptimizedSolution(_function, _rangeA, _rangeB);
        }

        public double GetFunctionValue()
        {
            return _function(_solution);
        }

        public ISolution Get(ISolution a, ISolution b, bool getBest = true)
        {
            OptimizedSolution solA = a as OptimizedSolution;
            OptimizedSolution solB = b as OptimizedSolution;

            if (solA != null && solB != null)
            {
                double aVal = solA.GetFunctionValue();
                double bVal = solB.GetFunctionValue();
                if (getBest)
                {
                    return aVal <= bVal ? a : b;
                }
                else
                {
                    return aVal <= bVal ? b : a;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
