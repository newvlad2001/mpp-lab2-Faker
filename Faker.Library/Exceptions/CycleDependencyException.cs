using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Library.Exceptions
{
    class CycleDependencyException : Exception
    {
        public CycleDependencyException(string message) : base(message)
        {

        }
    }
}
