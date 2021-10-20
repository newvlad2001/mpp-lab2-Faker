using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Library.Generators
{
    public interface IGenerator
    {
        public object Generate(Entity.GeneratorContext context);
    }
}
