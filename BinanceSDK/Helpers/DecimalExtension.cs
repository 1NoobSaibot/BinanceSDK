namespace BinanceSDK.Helpers
{
	internal static class DecimalExtension
	{
		public static decimal Mod(this decimal a, decimal b)
		{
			return a - (Math.Truncate(a / b) * b);
		}


		public static int TickSizeToPrecision(this decimal tickSize)
		{
			if (tickSize == 0)
			{
				return 8; // My default max precision
			}

			decimal testTickSize = 1;
			for (int i = 0; i < 20; i++)
			{
				if (tickSize == testTickSize)
				{
					return i;
				}

				testTickSize /= 10m;
			}

			throw new Exception("Cannot get precision of tickSize = " + tickSize);
		}
	}
}
