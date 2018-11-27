using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace HowToBenchmark
{
    [MemoryDiagnoser]
    public class BenchmarkDictionaryOrSwitchCase
    {
        private const int loopQuantity = 1000;

        private readonly Dictionary<string, string> CardNames =
            new Dictionary<string, string>()
            {
                {"MASTERCARD", "Master"},
                {"DISCOVER", "Master"},
                {"ARCHCARD", "Master"},
                {"DINERS", "Master"},
                {"JCB", "Master"},
                {"AMEX", "Master"}
            };

        [Benchmark]
        public void TryGetDictionaryValueToUpper()
        {
            for (int i = 0; i < loopQuantity; i++)
            {
                CardNames.TryGetValue("mastercard".ToUpper(), out var mastercard);
                CardNames.TryGetValue("discover".ToUpper(), out var discover);
                CardNames.TryGetValue("archcard".ToUpper(), out var archcard);
                CardNames.TryGetValue("diners".ToUpper(), out var diners);
                CardNames.TryGetValue("jcb".ToUpper(), out var jcb);
                CardNames.TryGetValue("amex".ToUpper(), out var amex);
            }
        }

        private readonly Dictionary<string, string> CardNamesWithIgnoreCase =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"MASTERCARD", "Master"},
                {"DISCOVER", "Master"},
                {"ARCHCARD", "Master"},
                {"DINERS", "Master"},
                {"JCB", "Master"},
                {"AMEX", "Master"}
            };

        [Benchmark]
        public void TryGetDictionaryValueWithDictionaryIgnoreCase()
        {
            for (int i = 0; i < loopQuantity; i++)
            {
                CardNamesWithIgnoreCase.TryGetValue("mastercard", out var mastercard);
                CardNamesWithIgnoreCase.TryGetValue("discover", out var discover);
                CardNamesWithIgnoreCase.TryGetValue("archcard", out var archcard);
                CardNamesWithIgnoreCase.TryGetValue("diners", out var diners);
                CardNamesWithIgnoreCase.TryGetValue("jcb", out var jcb);
                CardNamesWithIgnoreCase.TryGetValue("amex", out var amex);
            }
        }

        [Benchmark]
        public void SwitchCase()
        {
            for (int i = 0; i < loopQuantity; i++)
            {
                var mastercard = MapCardNames("mastercard");
                var discover = MapCardNames("discover");
                var archcard = MapCardNames("archcard");
                var diners = MapCardNames("diners");
                var jcb = MapCardNames("jcb");
                var amex = MapCardNames("amex");
            }
        }

        [Benchmark]
        public void IfElse()
        {
            for (int i = 0; i < loopQuantity; i++)
            {
                var mastercard = MapCardNamesUsingIf("mastercard");
                var discover = MapCardNamesUsingIf("discover");
                var archcard = MapCardNamesUsingIf("archcard");
                var diners = MapCardNamesUsingIf("diners");
                var jcb = MapCardNamesUsingIf("jcb");
                var amex = MapCardNamesUsingIf("amex");
            }
        }

        private string MapCardNames(string cashlessCardProvider)
        {
            switch (cashlessCardProvider.ToUpper())
            {
                case "MASTERCARD":
                    cashlessCardProvider = "Master";
                    break;
                case "DISCOVER":
                    cashlessCardProvider = "Dscvr";
                    break;
                case "ARCHCARD":
                    cashlessCardProvider = "Gift Card";
                    break;
                case "DINERS":
                    cashlessCardProvider = "Dscvr";
                    break;
                case "JCB":
                    cashlessCardProvider = "Dscvr";
                    break;
                case "AMEX":
                    cashlessCardProvider = "Amex";
                    break;
            }

            return cashlessCardProvider;
        }

        private string MapCardNamesUsingIf(string cashlessCardProvider)
        {
            if (string.Equals(cashlessCardProvider, "MASTERCARD", StringComparison.InvariantCultureIgnoreCase))
                cashlessCardProvider = "Master";
            else if (string.Equals(cashlessCardProvider, "DISCOVER", StringComparison.InvariantCultureIgnoreCase))
            {
                cashlessCardProvider = "Dscvr";
            }
            else if (string.Equals(cashlessCardProvider, "ARCHCARD", StringComparison.InvariantCultureIgnoreCase))
            {
                cashlessCardProvider = "Gift Card";
            }
            else if (string.Equals(cashlessCardProvider, "DINERS", StringComparison.InvariantCultureIgnoreCase))
            {
                cashlessCardProvider = "Dscvr";
            }
            else if (string.Equals(cashlessCardProvider, "JCB", StringComparison.InvariantCultureIgnoreCase))
            {
                cashlessCardProvider = "Dscvr";
            }
            else if (string.Equals(cashlessCardProvider, "AMEX", StringComparison.InvariantCultureIgnoreCase))
            {
                cashlessCardProvider = "Amex";
            }

            return cashlessCardProvider;
        }
    }
}