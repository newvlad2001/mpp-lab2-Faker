using System;
using System.Collections;
using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.Collections
{
    public class BitArrayGenerator : IGenerator
    {
        public BitArrayGenerator()
        {
            
        }
        
        public object Generate(GeneratorContext context)
        {
            var size = context.Random.Next(1, 20);
            var array = new bool[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = Convert.ToBoolean(context.Random.Next(0, 1));
            }
            
            return new BitArray(array);
        }

        public string GetGeneratorType()
        {
            return typeof(BitArray).ToString();
        }
    }
}