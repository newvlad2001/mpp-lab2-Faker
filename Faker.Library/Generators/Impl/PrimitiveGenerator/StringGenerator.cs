using Faker.Library.Generators;
using Faker.Library.Generators.Entity;
using System.Text;

namespace Faker.Generator.ScalarValues
{
    public class StringGenerator : IGenerator
    {
        public StringGenerator()
        {
            
        }
        
        public object Generate(GeneratorContext context)
        {
            var size = context.Random.Next(1, 20);
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < size; i++)
                stringBuilder.Append((char) context.Random.Next());

            return stringBuilder.ToString();
        }

        public string GetGeneratorType()
        {
            return typeof(string).ToString();
        }
    }
}