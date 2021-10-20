using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.Collections
{
    public class QueueGenerator<T> : IGenerator
    {

        public QueueGenerator()
        {
            
        }
        
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

        public string GetGeneratorType()
        {
            return typeof(Queue<T>).ToString();
        }
    }
}