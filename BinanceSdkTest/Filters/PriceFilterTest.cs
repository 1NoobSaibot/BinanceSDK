using BinanceSDK.Filters;

namespace BinanceSdkTest.Filters
{
	[TestClass]
	public class PriceFilterTest
	{
		[TestMethod]
		public void ShouldFilterCorrect()
		{
			foreach (var pair in _examples)
			{
				var filter = pair.Key;
				var samples = pair.Value;
				foreach (var sample in samples)
				{
					Assert.AreEqual(sample.isValid, filter.IsPriceValid(sample.price));
				}
			}
		}


		private Dictionary<PriceFilter, List<(decimal price, bool isValid)>> _examples
			= new Dictionary<PriceFilter, List<(decimal price, bool isValid)>>()
			{
				{ 
					new PriceFilter(0, 0, 0),
					new List<(decimal price, bool isValid)>()
					{
						(0, true),
						(1000, true),
						(-1, false),
						(0.0000000001m, true)
					}
				},
				{
					new PriceFilter(5, 0, 0),
					new List<(decimal price, bool isValid)>()
					{
						(0, false),
						(-1, false),
						(4, false),
						(4.9999999999999m, false),
						(5, true),
						(6, true),
						(1000, true),
						(7.0000000001m, true)
					}
				},
				{
					new PriceFilter(0, 100, 0),
					new List<(decimal price, bool isValid)>()
					{
						(0, true),
						(-1, false),
						(4, true),
						(4.9999999999999m, true),
						(5, true),
						(1000, false),
						(0.0000000001m, true)
					}
				},
				{
					new PriceFilter(5, 100, 0),
					new List<(decimal price, bool isValid)>()
					{
						(0, false),
						(-1, false),
						(4, false),
						(4.9999999999999m, false),
						(5, true),
						(6, true),
						(100, true),
						(100.00000001m, false),
						(1000, false),
						(8.0000000001m, true)
					}
				},
				{
					new PriceFilter(0, 0, 0.01m),
					new List<(decimal price, bool isValid)>()
					{
						(0, true),
						(-1, false),
						(4, true),
						(4.9999999999999m, false),
						(5.99m, true),
						(6.01m, true),
						(100, true),
						(100.00000001m, false),
						(1000.03m, true),
						(8.0000000001m, false)
					}
				},
			};
	}
}
