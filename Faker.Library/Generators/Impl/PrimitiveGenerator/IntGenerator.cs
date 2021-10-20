using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.ScalarValues
{
    public class IntGenerator : IGenerator
    {
        public IntGenerator()
        {
            
        }
        
        public object Generate(GeneratorContext context)
        {
            return context.Random.Next(int.MinValue, int.MaxValue);
        }

        public string GetGeneratorType()
        {
            return typeof(int).ToString();
        }
    }
}