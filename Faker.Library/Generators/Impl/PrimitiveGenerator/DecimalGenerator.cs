using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.ScalarValues
{
    public class DecimalGenerator : IGenerator
    {
        public DecimalGenerator()
        {
            
        }

        public object Generate(GeneratorContext context)
        {
            byte scale = (byte) context.Random.Next(29);
            bool sign = context.Random.Next(2) == 1;
            
            return new decimal(context.Random.Next(), context.Random.Next(), context.Random.Next(), sign, scale);
        }

        public string GetGeneratorType()
        {
            return typeof(decimal).ToString();
        }
    }
}