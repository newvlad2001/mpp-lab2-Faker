using Faker.Library.Generators;
using Faker.Library.Generators.Entity;
using System;

namespace Faker.Generator.ScalarValues
{
    public class SingleGenerator : IGenerator
    {
        public SingleGenerator()
        {
            
        }
        
        public object Generate(GeneratorContext context)
        {
            return (Single) context.Random.NextDouble();
        }

        public string GetGeneratorType()
        {
            return typeof(Single).ToString();
        }
    }
}