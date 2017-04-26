using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics.Core
{
    public abstract class GeneticAlgorithm
    {
        public virtual ISolution Solve()
        {
            var population = GeneratePopulation();

            WorkCircle(population);

            return population.GetBest();
        }

        protected abstract bool IsSolved();

        protected abstract Population GeneratePopulation();

        protected virtual void WorkCircle(Population population)
        {
            while (!IsSolved())
            {
                var subPopulation = population.GetSubPopulation(2);

                List<ISolution> mutants = new List<ISolution>();
                subPopulation.ForEach(s => { mutants.Add(s.Mutate()); });

                subPopulation.Add(mutants);

                population.DeleteTheWorst();

                population.Add(subPopulation.GetBest());
            }
        }
    }
}
