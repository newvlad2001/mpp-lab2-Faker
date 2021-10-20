using Faker.Library.Generators.Entity;
using System;

namespace Faker.Library.Generators.Impl.StructureGenerators
{
    class DateTimeGenerator : IGenerator
    {
        public DateTimeGenerator()
        {
        }

        public object Generate(GeneratorContext context)
        {
            var year = context.Random.Next(1, 10000);
            var month = context.Random.Next(1, 12);
            var day = context.Random.Next(1, DateTime.DaysInMonth(year, month));

            return new DateTime(year, month, day);
        }
    }
}
