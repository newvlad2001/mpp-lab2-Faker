﻿using Faker.Library.Generators.Entity;
using System;

namespace Faker.Library.Generators.Impl.BasicGenerators
{
    public class IntGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return context.Random.Next();
        }

        public bool CanGenerate(Type t)
        {
            return typeof(int) == t;
        }
    }
}