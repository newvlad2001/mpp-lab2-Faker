using System;
using System.Collections;
using Faker.Library.Generators.Entity;

namespace Faker.Library.Generators.Impl.CollectionGenerators
{
    public class QueueGenerator<T> : IGenerator
    {
        
        public object Generate(GeneratorContext context)
        {
            var size = context.Random.Next(1, 20);
            var stack = (Queue) Activator.CreateInstance(context.TargetType);
            
            for (int i = 0; i < size; i++)
            {
                stack.Enqueue(context.Faker.Create(context.TargetType.GetGenericArguments()[0]));
            }

            return stack;
        }
    }
}