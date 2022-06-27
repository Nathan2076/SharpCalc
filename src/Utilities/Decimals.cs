using System;
using Microsoft.Extensions.Configuration;

namespace SharpCalc.Utilities
{
    class Decimals
    {
        public static double RemoveExcessiveDecimals(double x)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("Configs/config.json").Build();
            int count = int.Parse(config["decimalsToKeep"]);

            double decimalsToKeep = Math.Pow(10, count);
            return Math.Truncate(decimalsToKeep * x) / decimalsToKeep;
        }
    }
}