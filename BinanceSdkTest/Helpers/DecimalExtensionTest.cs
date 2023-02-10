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
