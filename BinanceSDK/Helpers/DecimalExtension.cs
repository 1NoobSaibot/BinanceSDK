namespace BinanceSDK.Helpers
{
	internal static class DecimalExtension
	{
		public static decimal Mod(this decimal a, decimal b)
		{
			return a - (Math.Truncate(a / b) * b);
		}
	}
}
