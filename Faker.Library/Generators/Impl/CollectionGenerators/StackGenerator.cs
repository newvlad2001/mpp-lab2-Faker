using System;
using System.Collections;
using Faker.Library.Generators.Entity;

namespace Faker.Library.Generators.Impl.CollectionGenerators
{
    public class StackGenerator<T> : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            var size = context.Random.Next(1, 20);
            var stack = (Stack) Activator.CreateInstance(context.TargetType);
            for (int i = 0; i < size; i++)
            {
                stack.Push(context.Faker.Create(context.TargetType.GetGenericArguments()[0]));
            }

            return stack;
        }
    }
}