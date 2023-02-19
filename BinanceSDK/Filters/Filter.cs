using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace BinanceSDK.Filters
{
	[JsonConverter(typeof(FilterConverter))]
	public abstract class Filter
	{
		public const string FilterTypeKey = "filterType";

		[JsonProperty(FilterTypeKey)]
		public abstract FilterType Type { get; }


		private static Filter Deserialize(JObject jo) {
			string typeStr = jo[Filter.FilterTypeKey]!.Value<string>()!;
			FilterType type = Enum.Parse<FilterType>(typeStr);

			switch (type)
			{
				case FilterType.PRICE_FILTER:
					return new PriceFilter(jo);
				case FilterType.PERCENT_PRICE:
					return new PercentPriceFilter(jo);
				case FilterType.PERCENT_PRICE_BY_SIDE:
					return new PercentPriceBySideFilter(jo);
				case FilterType.LOT_SIZE:
					return new LotSizeFilter(jo);
				case FilterType.MIN_NOTIONAL:
					return new MinNotionalFilter(jo);
				case FilterType.NOTIONAL:
					return new NotionalFilter(jo);
				case FilterType.ICEBERG_PARTS:
					return new IcebergPartsFilter(jo);
				case FilterType.MARKET_LOT_SIZE:
					return new MarketLotSizeFilter(jo);
				case FilterType.MAX_NUM_ORDERS:
					return new MaxNumOrdersFilter(jo);
				case FilterType.MAX_NUM_ALGO_ORDERS:
					return new MaxNumAlgoOrdersFilter(jo);
				case FilterType.MAX_NUM_ICEBERG_ORDERS:
					return new MaxNumIcebergOrdersFilter(jo);
				case FilterType.MAX_POSITION:
					return new MaxPositionFilter(jo);
				case FilterType.TRAILING_DELTA:
					return new TrailingDeltaFilter(jo);
				case FilterType.EXCHANGE_MAX_NUM_ORDERS:
					return new ExchangeMaxNumOrdersFilter(jo);
				case FilterType.EXCHANGE_MAX_NUM_ALGO_ORDERS:
					return new ExchangeMaxNumAlgoOrdersFilter(jo);
				case FilterType.EXCHANGE_MAX_NUM_ICEBERG_ORDERS:
					return new ExchangeMaxNumIcebergOrdersFilter(jo);
			}
			throw new NotImplementedException();
		}


		private class FilterConverter : JsonConverter
		{
			static JsonSerializerSettings SpecifiedSubclassConversion
				= new JsonSerializerSettings() {
					ContractResolver = new FilterResolver()
				};

			public override bool CanConvert(Type objectType)
			{
				return objectType == typeof(Filter);
			}

			public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				JObject jo = JObject.Load(reader);
				return Filter.Deserialize(jo);
			}

			public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
			{
				throw new NotImplementedException();
			}

			public override bool CanWrite => false;
		}


		private class FilterResolver : DefaultContractResolver
		{
			protected override JsonConverter? ResolveContractConverter(Type objectType)
			{
				if (typeof(Filter).IsAssignableFrom(objectType) && !objectType.IsAbstract)
				{
					return null;
				}

				return base.ResolveContractConverter(objectType);
			}
		}
	}
}
