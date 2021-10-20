﻿using System;
using System.Collections;
using System.Collections.Generic;
using Faker.Library.Generators;
using Faker.Library.Generators.Entity;

namespace Faker.Generator.Collections
{
    public class ListGenerator : IGenerator
    {

        public ListGenerator()
        {
            
        }
        
        public object Generate(GeneratorContext context)
        {
            var size = context.Random.Next(1, 20);
            var list = (IList) Activator.CreateInstance(context.TargetType);

            for (int i = 0; i < size; i++)
            {
                list.Add(context.Faker.Create(context.TargetType.GetGenericArguments()[0]));
            }

            return list;
        }

        public string GetGeneratorType()
        {
            return "";
            //return typeof(List<T>).ToString();
        }
    }
}