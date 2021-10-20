using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.ScalarValues
{
    public class LongGenerator : IGenerator
    {
        public LongGenerator()
        {
            
        }
        
        public object Generate(GeneratorContext context)
        {
            long result = context.Random.Next(int.MinValue >> 32, int.MaxValue >> 32);
            
            result = (result << 32);
            result |= context.Random.Next(int.MinValue, int.MaxValue);
            
            return result;
            
        }

        public string GetGeneratorType()
        {
            return typeof(long).ToString();
        }
    }
}