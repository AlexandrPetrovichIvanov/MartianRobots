using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MartianRobots.Tests.Framework
{
    internal static class TestsRunner
    {
        internal static void RunAll()
        {
            var assembly = Assembly.GetAssembly(typeof(TestsRunner))!;
            var testsTypes = assembly.GetTypes().Where(
                type => type.CustomAttributes.Any(
                    attr => attr.AttributeType == typeof(TestClassAttribute)));

            foreach (var testType in testsTypes)
                RunTestMethods(testType);

            var allTestsCount = testsTypes.SelectMany(type => GetTestMethods(type)).Count();
            Console.WriteLine($"All {allTestsCount} tests passed");
        }

        private static void RunTestMethods(Type testType)
        {
            foreach (var method in GetTestMethods(testType))
            {
                method.Invoke(
                    method.IsStatic ? null : Activator.CreateInstance(testType),
                    null);
                Console.WriteLine($"{testType.Name}.{method.Name} passed");
            }
        }

        private static IEnumerable<MethodInfo> GetTestMethods(Type testType)
            => testType.GetMethods().Where(method => method.CustomAttributes.Any(
                attr => attr.AttributeType == typeof(TestMethodAttribute)));
    }
}