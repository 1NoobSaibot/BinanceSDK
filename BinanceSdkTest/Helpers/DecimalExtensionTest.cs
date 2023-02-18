using BinanceSDK.Helpers;

namespace BinanceSdkTest.Helpers
{
	[TestClass]
	public class DecimalExtensionTest
	{
		[TestMethod]
		public void ModShouldWorkAsWithIntegers()
		{
			_ForAll_I_J((i, j) =>
			{
				decimal expected = i % j;
				Assert.AreEqual(expected, ((decimal)i).Mod(j));
			});	
		}


		[TestMethod]
		public void ModWorksWithSmallerNumbers()
		{
			_ForAll_I_J((i, j) => {
				decimal _i = i / 100m;
				decimal _j = j / 100m;
				decimal expected = (i % j) / 100m;

				Assert.AreEqual(expected, _i.Mod(_j));
			});
		}


		[TestMethod]
		public void CanGetPrecisionOfTickSize()
		{
			(decimal, int)[] examples = new (decimal, int)[]
			{
				(1, 0),
				(0, 8),	// Default precision
				(0.1m, 1),
				(0.01m, 2),
				(0.001m, 3),
				(0.0001m, 4),
				(0.00001m, 5)
			};

			foreach (var example in examples)
			{
				int expected = example.Item2;
				int actual = example.Item1.TickSizeToPrecision();
				Assert.AreEqual(expected, actual);
			}
		}


		private void _ForAll_I_J(Action<int, int> test)
		{
			for (int i = -100; i <= 100; i++)
			{
				for (int j = -100; j <= 100; j++)
				{
					if (j == 0)
					{
						continue;
					}

					test(i, j);
				}
			}
		}
	}
}
