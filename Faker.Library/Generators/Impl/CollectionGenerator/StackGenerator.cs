using System;
using System.Collections;
using System.Collections.Generic;
using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.Collections
{
    public class StackGenerator<T> : IGenerator
    {

        public StackGenerator()
        {
            
        }
        
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

        public string GetGeneratorType()
        {
            return typeof(Stack<T>).ToString();
        }
    }
}