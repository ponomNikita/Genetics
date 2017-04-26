using System;
using Genetics.Core;
using Genetics.Core.Optimizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Genetics.Tests
{
    [TestClass]
    public class OptimizerTests
    {
        private GeneticAlgorithm _solver;
        private Func<double, double> _function;

        [TestInitialize]
        public void SetUp()
        {
            _function = x => x * x;
            _solver = new Optimizer(_function, 0, 2, 20, 5);
        }

        [TestMethod]
        public void SolveTest1()
        {
            OptimizedSolution solution = _solver.Solve() as OptimizedSolution;

            Assert.IsTrue(solution.GetSolution() >= 0 && solution.GetSolution() <= 2);
        }
    }
}
