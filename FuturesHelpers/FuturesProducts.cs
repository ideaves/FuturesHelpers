using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuturesHelpers
{
	public static partial class FuturesHelpers
	{
		// # PRODUCT SPECIFICATIONS SWITCHED HERE
		static public void PopulateSpecificContractSeries(string rootSymbol, DateTime startDate, int numContracts)
		{
			switch (rootSymbol)
			{
				case "ES":
					FuturesSeriesGlobalDictionary[rootSymbol] = new ES_FuturesSeries(rootSymbol, startDate, numContracts);
					break;
				case "NQ":
					FuturesSeriesGlobalDictionary[rootSymbol] = new NQ_FuturesSeries(rootSymbol, startDate, numContracts);
					break;
				case "EC":
					FuturesSeriesGlobalDictionary[rootSymbol] = new EC_FuturesSeries(rootSymbol, startDate, numContracts);
					break;
				case "GC":
					FuturesSeriesGlobalDictionary[rootSymbol] = new GC_FuturesSeries(rootSymbol, startDate, numContracts);
					break;
				case "US":
					FuturesSeriesGlobalDictionary[rootSymbol] = new US_FuturesSeries(rootSymbol, startDate, numContracts);
					break;
				case "BTC":
					FuturesSeriesGlobalDictionary[rootSymbol] = new BTC_FuturesSeries(rootSymbol, startDate, numContracts);
					break;

				default:
					break;
			}
		}
	}

	// # PRODUCT SPECIFICATIONS AS CONCRETE INSTANCES OF THE ABSTRACT FuturesPrice
	public class ES_FuturesSeries : FuturesSeries
	{
		DayOfWeek DayOfWeek = DayOfWeek.Wednesday;
		int seqInMonth = 3;

		public ES_FuturesSeries(string rootSymbol, DateTime startSeries, int nContracts) : base(rootSymbol)
		{
			ContractMonths = new string[] { "H", "M", "U", "Z" }.ToList();
			EnumerateContractSeries(rootSymbol, startSeries, nContracts);
		}

		public override DateTime? GetLastNonCommercialTradingDate(DateTime monthStart)
		{
			return GetNthWeekdayOfMonth(monthStart, seqInMonth, DayOfWeek);
		}
	}

	public class NQ_FuturesSeries : FuturesSeries
	{
		DayOfWeek DayOfWeek = DayOfWeek.Wednesday;
		int seqInMonth = 3;

		public NQ_FuturesSeries(string rootSymbol, DateTime startSeries, int nContracts) : base(rootSymbol)
		{
			ContractMonths = new string[] { "H", "M", "U", "Z" }.ToList();
			EnumerateContractSeries(rootSymbol, startSeries, nContracts);
		}

		public override DateTime? GetLastNonCommercialTradingDate(DateTime monthStart)
		{
			return GetNthWeekdayOfMonth(monthStart, seqInMonth, DayOfWeek);
		}
	}

	public class EC_FuturesSeries : FuturesSeries
	{
		DayOfWeek DayOfWeek = DayOfWeek.Wednesday;
		int seqInMonth = 3;

		public EC_FuturesSeries(string rootSymbol, DateTime startSeries, int nContracts) : base(rootSymbol)
		{
			ContractMonths = new string[] { "H", "M", "U", "Z" }.ToList();
			EnumerateContractSeries(rootSymbol, startSeries, nContracts);
		}

		public override DateTime? GetLastNonCommercialTradingDate(DateTime monthStart)
		{
			return GetNthWeekdayOfMonth(monthStart, seqInMonth, DayOfWeek);
		}
	}

	public class US_FuturesSeries : FuturesSeries
	{
		DayOfWeek DayOfWeek = DayOfWeek.Wednesday;
		int seqInMonth = 3;

		public US_FuturesSeries(string rootSymbol, DateTime startSeries, int nContracts) : base(rootSymbol)
		{
			ContractMonths = new string[] { "H", "M", "U", "Z" }.ToList();
			EnumerateContractSeries(rootSymbol, startSeries, nContracts);
		}

		public override DateTime? GetLastNonCommercialTradingDate(DateTime monthStart)
		{
			return GetNthWeekdayOfMonth(monthStart, seqInMonth, DayOfWeek);
		}
	}

	public class BTC_FuturesSeries : FuturesSeries
	{
		DayOfWeek DayOfWeek = DayOfWeek.Friday;

		public BTC_FuturesSeries(string rootSymbol, DateTime startSeries, int nContracts) : base(rootSymbol)
		{
			ContractMonths = new string[] { "F", "G", "H", "J", "K", "M", "N", "Q", "U", "V", "X", "Z" }.ToList();
			EnumerateContractSeries(rootSymbol, startSeries, nContracts);
		}

		public override DateTime? GetLastNonCommercialTradingDate(DateTime monthStart)
		{
			return GetLastWeekdayOfMonth(monthStart, 0, DayOfWeek);
		}
	}

	public class GC_FuturesSeries : FuturesSeries
	{
		public GC_FuturesSeries(string rootSymbol, DateTime startSeries, int nContracts) : base(rootSymbol)
		{
			ContractMonths = new string[] { "G", "J", "M", "Q", "Z" }.ToList();
			EnumerateContractSeries(rootSymbol, startSeries, nContracts);
		}

		public override DateTime? GetLastNonCommercialTradingDate(DateTime monthStart)
		{
			// Policy decision here - use GC first notice day as the last trading date. Brokers disallow trading,
			// even though the exchange technically has the contract designated as open for trading.
			return GetLastBusinessDayOfPriorMonth(monthStart);
		}
	}
}