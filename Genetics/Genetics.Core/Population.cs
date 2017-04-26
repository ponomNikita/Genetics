using System;
using System.Collections.Generic;

namespace Genetics.Core
{
    public abstract class Population
    {
        private readonly List<ISolution> _solutions;

        public Population(List<ISolution> solutions)
        {
            _solutions = solutions;
        }

        public virtual void Add(ISolution solution)
        {
            _solutions.Add(solution);
        }

        public virtual void ForEach(Action<ISolution> action)
        {
            foreach (var solution in _solutions)
            {
                action(solution);
            }
        }

        public virtual ISolution GetBest()
        {
            return GetSolution(new GetBestSolutionStrategy());
        }

        public virtual ISolution GetTheWorst()
        {
            return GetSolution(new GetWorstSolutionStrategy());
        }

        public abstract Population GetSubPopulation(int size);

        public virtual void Add(List<ISolution> solutions)
        {
            _solutions.AddRange(solutions);
        }

        public virtual void DeleteTheWorst()
        {
            _solutions.Remove(GetTheWorst());
        }

        private ISolution GetSolution(ICompareSolutionStrategy strategy)
        {
            ISolution res = _solutions[0];

            this.ForEach(s =>
            {
                res = s.Get(s, res, strategy);
            });

            return res;
        }
    }
}