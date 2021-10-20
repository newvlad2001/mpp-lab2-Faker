using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Faker.Library.Comparators;
using Faker.Library.Exceptions;
using Faker.Library.Generators;
using Faker.Library.Generators.Entity;
using Faker.Library.Generators.Impl.BasicGenerators;
using Faker.Library.Generators.Impl.CollectionGenerators;
using Faker.Library.Generators.Impl.StructureGenerators;

namespace Faker.Library.Logic.Impl
{
    public class Faker : IFaker
    {
        private Dictionary<string, IGenerator> _generators;
        private static List<Type> _cycleDependClassHolder;
        private static Random _randomizer;

        public Faker()
        {
            _generators = new Dictionary<string, IGenerator>();
            _randomizer = new Random();
            _cycleDependClassHolder = new List<Type>();

            LoadGenerators();
        }

        private void LoadGenerators()
        {
            _generators.Add(typeof(string).ToString(), new StringGenerator());
            _generators.Add(typeof(DateTime).ToString(), new DateTimeGenerator());
            _generators.Add(typeof(char).ToString(), new CharGenerator());
            _generators.Add(typeof(int).ToString(), new IntGenerator());
            _generators.Add(Regex.Replace(typeof(List<>).ToString(), "`.+$", string.Empty), new ListGenerator());
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type type)
        {
            try
            {
                if (type.IsGenericType)
                {
                    try
                    {
                        return _generators.ContainsKey(Regex.Replace(type.ToString(), "`.+$", string.Empty))
                            ? _generators[Regex.Replace(type.ToString(), "`.+$", string.Empty)]
                                .Generate(new GeneratorContext(_randomizer, type, this))
                            : CreateObject(type);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                else
                {
                    return _generators.ContainsKey(type.ToString()) 
                        ? _generators[type.ToString()]
                            .Generate(new GeneratorContext(_randomizer, type, this)) 
                        : CreateObject(type);
                }
            }
            catch (CycleDependencyException)
            {
                if (_cycleDependClassHolder.Count == 0) return null;

                throw;
            }

        }

        private object CreateObject(Type type)
        {
            object obj = null;

            if (_cycleDependClassHolder.Contains(type))
            {
                throw new CycleDependencyException("Cycle Dependency exception was found");
            }

            _cycleDependClassHolder.Add(type);

            try
            {
                obj = InitConstructor(GetSortedConstructorInfos(type, new ConstrucrorArgumentAmountComparerDesc()));
                InitFields(obj, type.GetFields());
                InitProperties(obj, type.GetProperties());
            }
            catch (Exception)
            {
                // ignored
            }

            _cycleDependClassHolder.Remove(type);
            return obj;
        }

        private object InitConstructor(IEnumerable<ConstructorInfo> constructors)
        {

            object obj = null;
            if (obj == null) throw new Exception("Faker can't crate object of class " + obj.GetType().Name);
            return obj;
        }


        private void InitFields(object obj, IEnumerable<FieldInfo> fields)
        {
            var defaultConstr = obj.GetType().GetConstructors()[0];
            var defaultObj = defaultConstr.Invoke(new object[defaultConstr.GetParameters().Length]);

            foreach (var field in fields)
            {
                var defaultValue = field.GetValue(defaultObj);
                var value = field.GetValue(obj);

                if (defaultValue == null && value != null) continue;
                if (value != null && !defaultValue.Equals(value)) continue;
            }

        }

        private void InitProperties(object obj, IEnumerable<PropertyInfo> properties)
        {
            var defaultConstr = obj.GetType().GetConstructors()[0];
            var defaultObj = defaultConstr.Invoke(new object[defaultConstr.GetParameters().Length]);

            foreach (var property in properties)
            {
                var defaultValue = property.GetValue(defaultObj);
                var value = property.GetValue(obj);

                if (defaultValue == null && value != null) continue;
                if (value != null && !defaultValue.Equals(value)) continue;
            }
        }

        private IEnumerable<ConstructorInfo> GetSortedConstructorInfos(Type type, IComparer<ConstructorInfo> constrCompare)
        {
            var constructorsInfoList = type.GetConstructors().ToList();
            constructorsInfoList.Sort(constrCompare);

            return constructorsInfoList;
        }
    }
}
