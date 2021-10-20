using Faker.Library.Logic;
using System;

namespace Faker.Library
{
    public class Faker : IFaker
    {
        public T Create<T>()
        {
            throw new NotImplementedException();
        }
    }
}
