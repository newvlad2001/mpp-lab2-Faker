using Faker.Library.Generators.Entity;
using System;

namespace Faker.Library.Generators.Impl.BasicGenerators
{
    public class CharGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return Convert.ToChar(context.Random.Next(char.MinValue, char.MaxValue));
        }
    }
}
