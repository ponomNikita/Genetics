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
            return null;
        }
    }
}
