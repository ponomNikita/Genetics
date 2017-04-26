﻿namespace Genetics.Core
{
    public interface ISolution
    {
        ISolution Mutate();
        ISolution Get(ISolution a, ISolution b, ICompareSolutionStrategy stratagy);
    }
}