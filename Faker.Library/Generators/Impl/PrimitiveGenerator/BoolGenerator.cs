using Faker.Library.Generators;
using Faker.Library.Generators.Entity;
using System;

namespace Faker.Generator.ScalarValues
{
    public class BoolGenerator : IGenerator
    {
        public BoolGenerator()
        {

        }

        public object Generate(GeneratorContext context)
        {
            return Convert.ToBoolean(context.Random.Next(0, 1));
        }

        public string GetGeneratorType()
        {
            return typeof(bool).ToString();
        }
    }
}