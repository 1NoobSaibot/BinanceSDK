using BinanceSDK.DTO;
using BinanceSDK.DTO.V3.Trade;
using BinanceSDK.Private;
using BinanceSdkTest.Helpers;

namespace BinanceSdkTest.Private
{
	[TestClass]
	public class PrivateDeserializationTest
	{
		private FakeWebClient _client = new FakeWebClient();
		private PrivateRest _api;


		public PrivateDeserializationTest()
		{
			_api = new PrivateRest(Env.Access, _client);
		}


		#region Reading Orders
		[TestMethod]
		public async Task ShouldReadOrderAsk()
		{
			const string json = "{\"symbol\":\"BTCUSDT\",\"orderId\":28,\"orderListId\":-1,\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"transactTime\":1507725176595}";
			_client.SetNextREsponceData(json);

			var order = await _api.PlaceOrderAck(TradeRequest.BuyMarket("BTCUSDT", -1));
			_TestOrderAsk(order);
		}


		[TestMethod]
		public async Task ShouldReadOrderResult()
		{
			const string json = "{\"symbol\":\"BTCUSDT\",\"orderId\":28,\"orderListId\":-1,\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"transactTime\":1507725176595,\"price\":\"0.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"10.00000000\",\"cummulativeQuoteQty\":\"10.00000000\",\"status\":\"FILLED\",\"timeInForce\":\"GTC\",\"type\":\"MARKET\",\"side\":\"SELL\",\"strategyId\":1,\"strategyType\":1000000,\"workingTime\":1507725176595,\"selfTradePreventionMode\":\"NONE\"}";
			_client.SetNextREsponceData(json);

			var order = await _api.PlaceOrderResult(TradeRequest.BuyMarket("BTCUSDT", -1));
			_TestOrderResult(order);
		}


		[TestMethod]
		public async Task ShouldReadOrderFull()
		{
			const string json = "{\"symbol\":\"BTCUSDT\",\"orderId\":28,\"orderListId\":-1,\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"transactTime\":1507725176595,\"price\":\"0.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"10.00000000\",\"cummulativeQuoteQty\":\"10.00000000\",\"status\":\"FILLED\",\"timeInForce\":\"GTC\",\"type\":\"MARKET\",\"side\":\"SELL\",\"strategyId\":1,\"strategyType\":1000000,\"workingTime\":1507725176595,\"selfTradePreventionMode\":\"NONE\",\"fills\":[{\"price\":\"4000.00000000\",\"qty\":\"1.00000000\",\"commission\":\"4.00000000\",\"commissionAsset\":\"USDT\",\"tradeId\":56},{\"price\":\"3999.00000000\",\"qty\":\"5.00000000\",\"commission\":\"19.99500000\",\"commissionAsset\":\"USDT\",\"tradeId\":57},{\"price\":\"3998.00000000\",\"qty\":\"2.00000000\",\"commission\":\"7.99600000\",\"commissionAsset\":\"USDT\",\"tradeId\":58},{\"price\":\"3997.00000000\",\"qty\":\"1.00000000\",\"commission\":\"3.99700000\",\"commissionAsset\":\"USDT\",\"tradeId\":59},{\"price\":\"3995.00000000\",\"qty\":\"1.00000000\",\"commission\":\"3.99500000\",\"commissionAsset\":\"USDT\",\"tradeId\":60}]}";
			_client.SetNextREsponceData(json);

			var order = await _api.PlaceOrderFull(TradeRequest.BuyMarket("BTCUSDT", -1));
			_TestOrderFull(order);
		}
		#endregion


		#region Reading Snapshots
		[TestMethod]
		public async Task ShouldReadSnapshotFutures()
		{
			const string json = "{\"code\":200,\"msg\":\"\",\"snapshotVos\":[{\"data\":{\"assets\":[{\"asset\":\"USDT\",\"marginBalance\":\"118.99782335\",\"walletBalance\":\"120.23811389\"}],\"position\":[{\"entryPrice\":\"7130.41000000\",\"markPrice\":\"7257.66239673\",\"positionAmt\":\"0.01000000\",\"symbol\":\"BTCUSDT\",\"unRealizedProfit\":\"1.24029054\"}]},\"type\":\"futures\",\"updateTime\":1576281599000}]}";
			_client.SetNextREsponceData(json);

			var snapshot = await _api.GetFuturesDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("futures", snapshot.Snapshots[0].Type);
		}


		[TestMethod]
		public async Task ShouldReadSnapshotMargin()
		{
			const string json = "{\"code\":200,\"msg\":\"\",\"snapshotVos\":[{\"data\":{\"marginLevel\":\"2748.02909813\",\"totalAssetOfBtc\":\"0.00274803\",\"totalLiabilityOfBtc\":\"0.00000100\",\"totalNetAssetOfBtc\":\"0.00274750\",\"userAssets\":[{\"asset\":\"XRP\",\"borrowed\":\"0.00000000\",\"free\":\"1.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"1.00000000\"}]},\"type\":\"margin\",\"updateTime\":1576281599000}]}";
			_client.SetNextREsponceData(json);

			var snapshot = await _api.GetMarginDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("margin", snapshot.Snapshots[0].Type);
		}


		[TestMethod]
		public async Task ShouldReadSnapshotSpot()
		{
			const string json = $"{{\"code\":200,\"msg\":\"\",\"snapshotVos\":[{{\"data\":{{\"balances\":[{{\"asset\":\"BTC\",\"free\":\"0.09905021\",\"locked\":\"0.00000000\"}},{{\"asset\":\"USDT\",\"free\":\"1.89109409\",\"locked\":\"0.00000000\"}}],\"totalAssetOfBtc\":\"0.09942700\"}},\"type\":\"spot\",\"updateTime\":1576281599000}}]}}";
			_client.SetNextREsponceData(json);

			var snapshot = await _api.GetSpotDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("spot", snapshot.Snapshots[0].Type);
		}
		#endregion


		[TestMethod]
		public async Task ShouldReadWithdrawResponce()
		{
			const string ID = "7213fea8e94b4a5593d507237e5a555b";
			_client.SetNextREsponceData($"{{\"id\":\"{ID}\"}}");
			var res = await _api.Withdraw("USDT", "fakeAddress", 0);
			Assert.IsNotNull(res);
			Assert.AreEqual(ID, res.ID);
		}


		private void _TestOrderFull(OrderFull order)
		{
			_TestOrderResult(order);

			Assert.AreEqual(5, order!.Fills!.Length);
			Assert.AreEqual(4000, order!.Fills[0].Price);
			Assert.AreEqual(1, order!.Fills[0].Quantity);
			Assert.AreEqual(4, order!.Fills[0].Comission);
			Assert.AreEqual("USDT", order!.Fills[0].CommissionAsset);
			Assert.AreEqual(56, order!.Fills[0].TradeID);
		}


		private void _TestOrderResult(OrderResult order)
		{
			_TestOrderAsk(order);

			Assert.AreEqual(0, order.Price);
			Assert.AreEqual(10, order.OriginQuantity);
			Assert.AreEqual(10, order.ExecutedQuantity);
			Assert.AreEqual(10, order.CummulativeQuoteQty);
			Assert.AreEqual(OrderStatus.FILLED, order.Status);
			Assert.AreEqual(TimeInForce.GTC, order.TimeInForce);
			Assert.AreEqual(OrderType.MARKET, order.Type);
			Assert.AreEqual(OrderSide.SELL, order.Side);
			Assert.AreEqual(1, order.StrategyID);
			Assert.AreEqual(1000000, order.StrategyType);
			Assert.AreEqual(1507725176595, order.WorkingTime);
			Assert.AreEqual(TradePreventionMode.NONE, order.SelfTradePreventionMode);
		}


		private void _TestOrderAsk(OrderAck order)
		{
			Assert.IsNotNull(order);
			Assert.AreEqual("BTCUSDT", order.Symbol);
			Assert.AreEqual(28, order.ID);
			Assert.AreEqual(-1, order.OrderListID);
			Assert.AreEqual("6gCrw2kRUAF9CvJDGP16IP", order.ClientOrderID);
			Assert.AreEqual("BTCUSDT", order.Symbol);
			Assert.AreEqual(1507725176595, order.TransactTime);
		}
	}
}