using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuturesHelpers;

namespace FuturesHelpers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example of usage
            // # 1 Import a holiday list from your holiday list provider, or make a CSV list to import.
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(new DateTime(2023, 1, 16));
            holidays.Add(new DateTime(2023, 2, 13));
            holidays.Add(new DateTime(2023, 3, 24));
            holidays.Add(new DateTime(2023, 5, 29));
            holidays.Add(new DateTime(2023, 7, 4));
            holidays.Add(new DateTime(2023, 8, 28));
            holidays.Add(new DateTime(2023, 10, 31));
            holidays.Add(new DateTime(2023, 11, 23));


            // # 2 Define the kinds of futures contracts you want to use.
            FuturesSeries[] globalFuturesContracts = new FuturesSeries[6];
            globalFuturesContracts[0] = new ES_FuturesSeries("ES", DateTime.Now, 3);
            globalFuturesContracts[1] = new EC_FuturesSeries("EC", DateTime.Now, 3);
            globalFuturesContracts[2] = new US_FuturesSeries("US", DateTime.Now, 3);
            globalFuturesContracts[3] = new GC_FuturesSeries("GC", DateTime.Now, 3);
            globalFuturesContracts[4] = new BTC_FuturesSeries("BTC", DateTime.Now, 3);
            globalFuturesContracts[5] = new NQ_FuturesSeries("NQ", DateTime.Now, 3);

            // #3 Reference all the normal things you need to know about futures contracts.
            // Those can be like normal non-futures securities, now that the idosyncrasies
            // of futures contracts have been sorted out.
            foreach (FuturesSeries ser in globalFuturesContracts)
            {
                DateTime startThisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime startNextMonth = new DateTime(startThisMonth.Month == 12 ? startThisMonth.Year + 1 : startThisMonth.Year, startThisMonth.Month == 12 ? 1 : startThisMonth.Month, 1);
                DateTime? thisLast = ser.GetLastNonCommercialTradingDate(startThisMonth);
                DateTime? thisNext = ser.GetLastNonCommercialTradingDate(startNextMonth);
                Console.WriteLine("{0}, {1}", thisLast, thisNext);

                Tuple<FuturesContractSpecifications, FuturesPrice> fut = FuturesHelpers.GetFrontContract(DateTime.Now, ser.SymbolRoot);
                Console.WriteLine("{0}, {1}, {2}, {3}", fut.Item1.SymbolRoot, fut.Item1.NonCommercialLastTradingDate, fut.Item2.Symbol, fut.Item2.LastPrice);
            }

            // Use cases might include needing an interpolated constant-maturity forward price.
            // You could also track spreads and incremental volume.
        }
    }
}
