using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    [MemoryDiagnoser]
    public class BenchmarkConvertingObjects
    {
        public const int Loop = 10;

        public void LoopAction(Action action)
        {
            for (var i = 0; i < Loop; i++)
            {
                action();
            }
        }

        public List<MyObject1> GetObjectsList()
        {
            var o1 = new MyObject1
            {
                Info = "Mocked Information",
                Id = "1",
                ListIds = new List<string> { "Item1", "Item2", "Item3", "Item4" },
                ListNames = new List<string> { "Name1", "Name2" },
                Name = "Mocked Name"
            };

            var o2 = new MyObject1
            {
                Info = "Mocked Information",
                Id = "1",
                ListIds = new List<string> { "Item1", "Item2", "Item3", "Item4" },
                ListNames = new List<string> { "Name1", "Name2" },
                Name = "Mocked Name"
            };

            var o3 = new MyObject1
            {
                Info = "Mocked Information",
                Id = "1",
                ListIds = new List<string> { "Item1", "Item2", "Item3", "Item4" },
                ListNames = new List<string> { "Name1", "Name2" },
                Name = "Mocked Name"
            };

            var o4 = new MyObject1
            {
                Info = "Mocked Information",
                Id = "1",
                ListIds = new List<string> { "Item1", "Item2", "Item3", "Item4" },
                ListNames = new List<string> { "Name1", "Name2" },
                Name = "Mocked Name"
            };

            var myList = new List<MyObject1>
            {
                o1,
                o2,
                o3,
                o4,
            };

            return myList;
        }

        [Benchmark]
        public void UsingReflection()
        {
            var objectList = GetObjectsList();
            var object2 = new MyObject2();

            LoopAction(() =>
            {
                objectList.ForEach(_ => { _.ConvertObjectTo(object2); });
            });
        }

        [Benchmark]
        public void NormalConvertion()
        {
            var objectList = GetObjectsList();
            var object2 = new MyObject2();

            LoopAction(() =>
            {
                objectList.ForEach(_ =>
                {
                    object2.Info = _.Info;
                    object2.Id = _.Id;
                    object2.ListIds = _.ListIds;
                    object2.ListNames = _.ListNames;
                    object2.Name = _.Name;
                });
            });
        }
    }

    public class MyObject1
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public List<string> ListNames { get; set; }
        public List<string> ListIds { get; set; }
    }

    public class MyObject2
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public List<string> ListNames { get; set; }
        public List<string> ListIds { get; set; }
    }

    public static class ObjectExtensions
    {
        public static object ConvertObjectTo<T>(this T obj, object obj2)
        {
            try
            {
                var arrayProperties = obj.GetType().GetProperties();
                var arrayProperties2 = obj2.GetType().GetProperties();

                foreach (var _ in arrayProperties)
                {
                    foreach (var x in arrayProperties2)
                    {
                        var comparedAttributes = _.PropertyType == x.PropertyType && _.Name == x.Name;

                        if (comparedAttributes)
                            x.SetValue(obj2, _.GetValue(obj, null), null);
                    }
                }
                return obj2;
            }
            catch
            {
                return null;
            }
        }
    }
}
