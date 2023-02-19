using BinanceSDK.Filters;
using Newtonsoft.Json;

namespace BinanceSdkTest.Filters
{
	[TestClass]
	public class SerializationTest
	{
		#region PriceFilter
		private const string PRICE_FILTER_JSON = @"{
			""filterType"": ""PRICE_FILTER"",
			""minPrice"": ""0.00000100"",
			""maxPrice"": ""100000.00000000"",
			""tickSize"": ""0.00000100""
		}";


		[TestMethod]
		public void ShouldDeserializePriceFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(PRICE_FILTER_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(PriceFilter));
			var pf = (PriceFilter)filter;

			Assert.AreEqual(FilterType.PRICE_FILTER, pf.Type);
			Assert.AreEqual(0.00000100m, pf.MinPrice);
			Assert.AreEqual(100000, pf.MaxPrice);
			Assert.AreEqual(0.00000100m, pf.TickSize);
		}
		#endregion


		#region PercentPrice
		private const string PERCENT_PRICE_JSON = @"{
			""filterType"": ""PERCENT_PRICE"",
			""multiplierUp"": ""1.3000"",
			""multiplierDown"": ""0.7000"",
			""avgPriceMins"": 5
		}";


		[TestMethod]
		public void ShouldDeserializePercentPriceFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(PERCENT_PRICE_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(PercentPriceFilter));
			var pf = (PercentPriceFilter)filter;
			Assert.AreEqual(FilterType.PERCENT_PRICE, pf.Type);
			Assert.AreEqual(1.3m, pf.MultiplierUp);
			Assert.AreEqual(0.7m, pf.MultiplierDown);
			Assert.AreEqual(5, pf.WeightedAveragePrice);
		}
		#endregion


		#region PercentPriceBySide
		private const string PERCENT_PRICE_BY_SIDE_JSON = @"{
      ""filterType"": ""PERCENT_PRICE_BY_SIDE"",
      ""bidMultiplierUp"": ""1.2"",
      ""bidMultiplierDown"": ""0.2"",
      ""askMultiplierUp"": ""5"",
      ""askMultiplierDown"": ""0.8"",
      ""avgPriceMins"": 1
    }";


		[TestMethod]
		public void ShouldDeserializePercentPriceBySideFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(PERCENT_PRICE_BY_SIDE_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(PercentPriceBySideFilter));
			var pf = (PercentPriceBySideFilter)filter;

			Assert.AreEqual(FilterType.PERCENT_PRICE_BY_SIDE, pf.Type);
			Assert.AreEqual(1.2m, pf.BidMultiplierUp);
			Assert.AreEqual(0.2m, pf.BidMultiplierDown);
			Assert.AreEqual(5, pf.AskMultiplierUp);
			Assert.AreEqual(0.8m, pf.AskMultiplierDown);
			Assert.AreEqual(1, pf.AvgPriceMins);
		}
		#endregion


		#region LotSize
		private const string LOT_SIZE_JSON = @"{
			""filterType"": ""LOT_SIZE"",
			""minQty"": ""0.00100000"",
			""maxQty"": ""100000.00000000"",
			""stepSize"": ""0.00100000""
		}";


		[TestMethod]
		public void ShouldDeserializeLotSizeFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(LOT_SIZE_JSON)!;
			Assert.IsInstanceOfType(filter, typeof(LotSizeFilter));
			var lsf = (LotSizeFilter)filter;

			Assert.AreEqual(FilterType.LOT_SIZE, lsf.Type);
			Assert.AreEqual(0.00100000m, lsf.MinQuantity);
			Assert.AreEqual(100000m, lsf.MaxQuantity);
			Assert.AreEqual(0.00100000m, lsf.StepSize);
		}
		#endregion



		#region MinNotional
		private const string MIN_NOTIONAL_JSON = @" {
			""filterType"": ""MIN_NOTIONAL"",
			""minNotional"": ""0.00100000"",
			""applyToMarket"": true,
			""avgPriceMins"": 5
		}";


		[TestMethod]
		public void ShouldDeserializeMinNotionalFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(MIN_NOTIONAL_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(MinNotionalFilter));
			var pf = (MinNotionalFilter)filter;

			Assert.AreEqual(FilterType.MIN_NOTIONAL, pf.Type);
			Assert.AreEqual(0.001m, pf.MinNotional);
			Assert.AreEqual(true, pf.ApplyToMarket);
			Assert.AreEqual(5, pf.AveragePriceForLastMinutes);
		}
		#endregion


		#region Notional
		private const string NOTIONAL_JSON = @"{
			""filterType"": ""NOTIONAL"",
			""minNotional"": ""10.00000000"",
			""applyMinToMarket"": false,
			""maxNotional"": ""10000.00000000"",
			""applyMaxToMarket"": false,
			""avgPriceMins"": 5
		}";


		[TestMethod]
		public void ShouldDeserializeNotionalFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(NOTIONAL_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(NotionalFilter));
			var pf = (NotionalFilter)filter;

			Assert.AreEqual(FilterType.NOTIONAL, pf.Type);
			Assert.AreEqual(10m, pf.MinNotional);
			Assert.AreEqual(false, pf.ApplyMinToMarket);
			Assert.AreEqual(10000m, pf.MaxNotional);
			Assert.AreEqual(false, pf.ApplyMaxToMarket);
			Assert.AreEqual(5, pf.ForLastMinutes);
		}
		#endregion


		#region IcebergParts
		private const string ICEBERG_PARTS_JSON = @"{
			""filterType"": ""ICEBERG_PARTS"",
			""limit"": 10
		}";


		[TestMethod]
		public void ShouldDeserializeIcebergPartsFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(ICEBERG_PARTS_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(IcebergPartsFilter));
			var pf = (IcebergPartsFilter)filter;

			Assert.AreEqual(FilterType.ICEBERG_PARTS, pf.Type);
			Assert.AreEqual(10, pf.Limit);
		}
		#endregion


		#region MarketLotSize
		private const string MARKET_LOT_SIZE_JSON = @"{
			""filterType"": ""MARKET_LOT_SIZE"",
			""minQty"": ""0.00100000"",
			""maxQty"": ""100000.00000000"",
			""stepSize"": ""0.00100000""
		}";


		[TestMethod]
		public void ShouldDeserializeMarketLotSizeFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(MARKET_LOT_SIZE_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(MarketLotSizeFilter));
			var pf = (MarketLotSizeFilter)filter;

			Assert.AreEqual(FilterType.MARKET_LOT_SIZE, pf.Type);
			Assert.AreEqual(0.001m, pf.MinQty);
			Assert.AreEqual(100000m, pf.MaxQty);
			Assert.AreEqual(0.001m, pf.StepSize);
		}
		#endregion


		#region MaxNumOrders
		private const string MAX_NUM_ORDERS_JSON = @"{
			""filterType"": ""MAX_NUM_ORDERS"",
			""maxNumOrders"": 25
		}";


		[TestMethod]
		public void ShouldDeserializeMaxNumOrdersFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(MAX_NUM_ORDERS_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(MaxNumOrdersFilter));
			var pf = (MaxNumOrdersFilter)filter;

			Assert.AreEqual(FilterType.MAX_NUM_ORDERS, pf.Type);
			Assert.AreEqual(25, pf.MaxNumOrders);
		}
		#endregion


		#region MaxNumAlgoOrders
		private const string MAX_NUM_ALGO_ORDERS_JSON = @"{
			""filterType"": ""MAX_NUM_ALGO_ORDERS"",
			""maxNumAlgoOrders"": 5
		}";


		[TestMethod]
		public void ShouldDeserializeMaxNumAlgoOrdersFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(MAX_NUM_ALGO_ORDERS_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(MaxNumAlgoOrdersFilter));
			var pf = (MaxNumAlgoOrdersFilter)filter;

			Assert.AreEqual(FilterType.MAX_NUM_ALGO_ORDERS, pf.Type);
			Assert.AreEqual(5, pf.MaxNumAlgoOrders);
		}
		#endregion


		#region MaxNumIcebergOrders
		private const string MAX_NUM_ICEBERG_ORDERS_JSON = @"{
			""filterType"": ""MAX_NUM_ICEBERG_ORDERS"",
			""maxNumIcebergOrders"": 3
		}";


		[TestMethod]
		public void ShouldDeserializeMaxNumIcebergOrdersFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(MAX_NUM_ICEBERG_ORDERS_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(MaxNumIcebergOrdersFilter));
			var pf = (MaxNumIcebergOrdersFilter)filter;

			Assert.AreEqual(FilterType.MAX_NUM_ICEBERG_ORDERS, pf.Type);
			Assert.AreEqual(3, pf.MaxNumIcebergOrders);
		}
		#endregion


		#region MaxPosition
		private const string MAX_POSITION_JSON = @"{
			""filterType"":""MAX_POSITION"",
			""maxPosition"":""10.00000000""
		}";


		[TestMethod]
		public void ShouldDeserializeMaxPositionFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(MAX_POSITION_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(MaxPositionFilter));
			var pf = (MaxPositionFilter)filter;

			Assert.AreEqual(FilterType.MAX_POSITION, pf.Type);
			Assert.AreEqual(10, pf.MaxPosition);
		}
		#endregion


		#region TrailingDelta
		private const string TRAILING_DELTA_JSON = @"{
      ""filterType"": ""TRAILING_DELTA"",
      ""minTrailingAboveDelta"": 30,
      ""maxTrailingAboveDelta"": 4000,
      ""minTrailingBelowDelta"": 10,
      ""maxTrailingBelowDelta"": 2000
   }";


		[TestMethod]
		public void ShouldDeserializeTrailingDeltaFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(TRAILING_DELTA_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(TrailingDeltaFilter));
			var pf = (TrailingDeltaFilter)filter;

			Assert.AreEqual(FilterType.TRAILING_DELTA, pf.Type);
			Assert.AreEqual(30, pf.MinTrailingAboveDelta);
			Assert.AreEqual(4000, pf.MaxTrailingAboveDelta);
			Assert.AreEqual(10, pf.MinTrailingBelowDelta);
			Assert.AreEqual(2000, pf.MaxTrailingBelowDelta);
		}
		#endregion


		#region ExchangeMaxNumOrders
		private const string EXCHANGE_MAX_NUM_ORDERS_JSON = @"{
			""filterType"": ""EXCHANGE_MAX_NUM_ORDERS"",
			""maxNumOrders"": 1000
		}";


		[TestMethod]
		public void ShouldDeserializeExchangeMaxNumOrdersFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(EXCHANGE_MAX_NUM_ORDERS_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(ExchangeMaxNumOrdersFilter));
			var pf = (ExchangeMaxNumOrdersFilter)filter;

			Assert.AreEqual(FilterType.EXCHANGE_MAX_NUM_ORDERS, pf.Type);
			Assert.AreEqual(1000, pf.MaxNumOrders);
		}
		#endregion


		#region ExchangeMaxNumAlgoOrders
		private const string EXCHANGE_MAX_NUM_ALGO_ORDERS_JSON = @"{
			""filterType"": ""EXCHANGE_MAX_NUM_ALGO_ORDERS"",
			""maxNumAlgoOrders"": 200
		}";


		[TestMethod]
		public void ShouldDeserializeExchangeMaxNumAlgoOrdersFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(EXCHANGE_MAX_NUM_ALGO_ORDERS_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(ExchangeMaxNumAlgoOrdersFilter));
			var pf = (ExchangeMaxNumAlgoOrdersFilter)filter;

			Assert.AreEqual(FilterType.EXCHANGE_MAX_NUM_ALGO_ORDERS, pf.Type);
			Assert.AreEqual(200, pf.MaxNumAlgoOrders);
		}
		#endregion


		#region ExchangeMaxNumIcebergOrders
		private const string EXCHANGE_MAX_NUM_ICEBERG_ORDERS_JSON = @"{
			""filterType"": ""EXCHANGE_MAX_NUM_ICEBERG_ORDERS"",
			""maxNumIcebergOrders"": 10000
		}";


		[TestMethod]
		public void ShouldDeserializeExchangeMaxNumIcebergOrdersFilterAsFilter()
		{
			Filter filter = JsonConvert.DeserializeObject<Filter>(EXCHANGE_MAX_NUM_ICEBERG_ORDERS_JSON)!;

			Assert.IsInstanceOfType(filter, typeof(ExchangeMaxNumIcebergOrdersFilter));
			var pf = (ExchangeMaxNumIcebergOrdersFilter)filter;

			Assert.AreEqual(FilterType.EXCHANGE_MAX_NUM_ICEBERG_ORDERS, pf.Type);
			Assert.AreEqual(10000, pf.MaxNumIcebergOrders);
		}
		#endregion
	}
}
