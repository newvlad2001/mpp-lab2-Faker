using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.ScalarValues
{
    public class DoubleGenerator : IGenerator
    {
        public DoubleGenerator()
        {
            
        }
        
        public object Generate(GeneratorContext context)
        {
            return context.Random.NextDouble();
        }

        public string GetGeneratorType()
        {
            return typeof(double).ToString();
        }
    }
}