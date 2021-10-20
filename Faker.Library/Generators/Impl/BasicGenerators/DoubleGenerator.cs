using Faker.Library.Generators.Entity;

namespace Faker.Library.Generators.Impl.BasicGenerators
{
    public class DoubleGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return context.Random.NextDouble();
        }
    }
}