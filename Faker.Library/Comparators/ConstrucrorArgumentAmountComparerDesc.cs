using System;
using System.Collections.Generic;
using System.Reflection;

namespace Faker.Library.Comparators
{
    public class ConstrucrorArgumentAmountComparerDesc : IComparer<ConstructorInfo>
    {
        public int Compare(ConstructorInfo x, ConstructorInfo y)
        {
            return y.GetParameters().Length - x.GetParameters().Length;
        }
    }
}
