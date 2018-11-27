using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    public static class ParameterExtensions
    {
        public static bool IsEquivalent(this ParameterInfo parameter1, ParameterInfo parameter2)
        {
            return parameter1.Name == parameter2.Name
                   && parameter1.ParameterType == parameter2.ParameterType
                   && parameter1.Position == parameter2.Position
                   && parameter1.IsIn == parameter2.IsIn
                   && parameter1.IsOut == parameter2.IsOut
                   && parameter1.IsOptional == parameter2.IsOptional;
        }
    }

    [MemoryDiagnoser]
    public class BenchmarkForAndWhere
    {
        internal class ClassToGetParameters
        {
            public void Method1(string textParameter, int integerParameter, bool booleanParameter)
            {
            }
        }

        public ParameterInfo[] GetParameters()
        {
            return new ClassToGetParameters().GetType().GetMethod("Method1").GetParameters();
        }
        private static bool IsEquivalent(ParameterInfo parameter1, ParameterInfo parameter2)
        {
            return parameter1.Name == parameter2.Name
                   && parameter1.ParameterType == parameter2.ParameterType
                   && parameter1.Position == parameter2.Position
                   && parameter1.IsIn == parameter2.IsIn
                   && parameter1.IsOut == parameter2.IsOut
                   && parameter1.IsOptional == parameter2.IsOptional;
        }

        [Benchmark]
        public bool For()
        {
            var parameters1 = GetParameters();
            var parameters2 = GetParameters();
            for (int i = 0; i < parameters1.Length; i++)
            {
                if (!parameters1[i].IsEquivalent(parameters2[i]))
                    return false;
            }

            return true;
        }

        [Benchmark]
        public bool Where()
        {
            var parameters1 = GetParameters();
            var parameters2 = GetParameters();

            return !parameters1.Where((parameter1, index) => !parameter1.IsEquivalent(parameters2[index])).Any();
        }
    }
}