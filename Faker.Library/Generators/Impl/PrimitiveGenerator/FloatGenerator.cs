using System;
using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.ScalarValues
{
    public class FloatGenerator : IGenerator
    {
        public FloatGenerator()
        {
            
        }

        public object Generate(GeneratorContext context)
        {
            double mantissa = (context.Random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, context.Random.Next(-126, 128));
            
            return (float)(mantissa * exponent);
        }

        public string GetGeneratorType()
        {
            return typeof(float).ToString();
        }
    }
}