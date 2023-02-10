using BinanceSDK.Helpers;

namespace BinanceSDK.DTO
{
	public class ChartIntervals : StringEnum
	{
		private ChartIntervals(string value) : base(value)
		{ }


		public static readonly ChartIntervals ASecond = new ChartIntervals("1s");
		public static readonly ChartIntervals AMinute = new ChartIntervals("1m");
		public static readonly ChartIntervals ThreeMinutes = new ChartIntervals("3m");
		public static readonly ChartIntervals FiveMinutes = new ChartIntervals("5m");
		public static readonly ChartIntervals FifteenMinutes = new ChartIntervals("15m");
		public static readonly ChartIntervals ThirtyMinutes = new ChartIntervals("30m");
		public static readonly ChartIntervals AnHour = new ChartIntervals("1h");
		public static readonly ChartIntervals TwoHours = new ChartIntervals("2h");
		public static readonly ChartIntervals FourHours = new ChartIntervals("4h");
		public static readonly ChartIntervals SixHours = new ChartIntervals("6h");
		public static readonly ChartIntervals EightHours = new ChartIntervals("8h");
		public static readonly ChartIntervals TwelveHours = new ChartIntervals("12h");
		public static readonly ChartIntervals Day = new ChartIntervals("1d");
		public static readonly ChartIntervals ThreeDays = new ChartIntervals("3d");
		public static readonly ChartIntervals Week = new ChartIntervals("1w");
		public static readonly ChartIntervals Month = new ChartIntervals("1M");
	}
}
