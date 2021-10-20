﻿using Faker.Library.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Library.Generators.Entity
{
    public class GeneratorContext
    {
        public Random Random { get; }
        public Type TargetType { get; }
        public IFaker Faker { get; }
        public GeneratorContext(Random random, Type targetType, IFaker faker)
        {
            Random = random;
            TargetType = targetType;
            Faker = faker;
        }
    }
}
