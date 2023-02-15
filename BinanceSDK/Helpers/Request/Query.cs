namespace BinanceSDK.Helpers.Request
{
	internal class Query : Attribute
	{
		public readonly string? ParamName;

		public Query(string? paramName = null) {
			ParamName = paramName;
		}
	}
}
