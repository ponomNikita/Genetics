using System;
using System.Collections.Generic;

namespace Genetics.Core
{
    public abstract class Population
    {
        public abstract void Add(ISolution solution);
        public abstract void ForEach(Action<ISolution> action);
        public abstract ISolution GetBest();
        public abstract Population GetSubPopulation(int size);
        public abstract void Add(List<ISolution> solutions);
        public abstract void DeleteTheWorst();
    }
}