using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics.Core.Optimizer
{
    public class OptimizedSolutionsPopulation : Population
    {
        public OptimizedSolutionsPopulation(List<ISolution> solutions) : base(solutions)
        {
        }

        public override Population GetSubPopulation(int size)
        {
            List<int> indexes = new List<int>();

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int solution;
                do
                {
                    solution = random.Next() % this.GetSize();
                } while (indexes.Any(ind => ind == solution));
                indexes.Add(solution);
            }

            List<ISolution> solutions = new List<ISolution>();
            indexes.ForEach(i => { solutions.Add(_solutions[i]);});

            return new OptimizedSolutionsPopulation(solutions);
        }

    }
}
