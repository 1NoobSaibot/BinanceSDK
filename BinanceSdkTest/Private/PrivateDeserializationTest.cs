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


		[TestMethod]
		public async Task ShouldDeserializeSpotSnapshot()
		{
			_client.SetNextREsponceData(SpotSnapshotExample);

			var snapshot = await _api.GetSpotDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("spot", snapshot.Snapshots[0].Type);
		}


		[TestMethod]
		public async Task ShouldDeserializeMarginSnapshot()
		{
			_client.SetNextREsponceData(MarginSnapshotExample);

			var snapshot = await _api.GetMarginDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("margin", snapshot.Snapshots[0].Type);
		}


		[TestMethod]
		public async Task ShouldDeserializeFuturesSnapshot()
		{
			_client.SetNextREsponceData(FuturesSnapshotExample);

			var snapshot = await _api.GetFuturesDailyAccountSnapshot();
			Assert.IsNotNull(snapshot);
			Assert.AreEqual(1, snapshot!.Snapshots!.Length);
			Assert.AreEqual("futures", snapshot.Snapshots[0].Type);
		}


		private const string SpotSnapshotExample = $"{{\r\n   \"code\":200, // 200 for success; others are error codes\r\n   \"msg\":\"\", // error message\r\n   \"snapshotVos\":[\r\n      {{\r\n         \"data\":{{\r\n            \"balances\":[\r\n               {{\r\n                  \"asset\":\"BTC\",\r\n                  \"free\":\"0.09905021\",\r\n                  \"locked\":\"0.00000000\"\r\n               }},\r\n               {{\r\n                  \"asset\":\"USDT\",\r\n                  \"free\":\"1.89109409\",\r\n                  \"locked\":\"0.00000000\"\r\n               }}\r\n            ],\r\n            \"totalAssetOfBtc\":\"0.09942700\"\r\n         }},\r\n         \"type\":\"spot\",\r\n         \"updateTime\":1576281599000\r\n      }}\r\n   ]\r\n}}";
		private const string MarginSnapshotExample = "{\r\n   \"code\":200, // 200 for success; others are error codes\r\n   \"msg\":\"\", // error message\r\n   \"snapshotVos\":[\r\n      {\r\n         \"data\":{\r\n            \"marginLevel\":\"2748.02909813\",\r\n            \"totalAssetOfBtc\":\"0.00274803\",\r\n            \"totalLiabilityOfBtc\":\"0.00000100\",\r\n            \"totalNetAssetOfBtc\":\"0.00274750\",\r\n            \"userAssets\":[\r\n               {\r\n                  \"asset\":\"XRP\",\r\n                  \"borrowed\":\"0.00000000\",\r\n                  \"free\":\"1.00000000\",\r\n                  \"interest\":\"0.00000000\",\r\n                  \"locked\":\"0.00000000\",\r\n                  \"netAsset\":\"1.00000000\"\r\n               }\r\n            ]\r\n         },\r\n         \"type\":\"margin\",\r\n         \"updateTime\":1576281599000\r\n      }\r\n   ]\r\n}";
		private const string FuturesSnapshotExample = "{\r\n   \"code\":200, // 200 for success; others are error codes\r\n   \"msg\":\"\", // error message\r\n   \"snapshotVos\":[\r\n      {\r\n         \"data\":{\r\n            \"assets\":[\r\n               {\r\n                  \"asset\":\"USDT\",\r\n                  \"marginBalance\":\"118.99782335\", // Not real-time data, can ignore\r\n                  \"walletBalance\":\"120.23811389\"\r\n               }\r\n            ],\r\n            \"position\":[\r\n               {\r\n                  \"entryPrice\":\"7130.41000000\",\r\n                  \"markPrice\":\"7257.66239673\",\r\n                  \"positionAmt\":\"0.01000000\",\r\n                  \"symbol\":\"BTCUSDT\",\r\n                  \"unRealizedProfit\":\"1.24029054\"  // Only show the value at the time of opening the position\r\n               }\r\n            ]\r\n         },\r\n         \"type\":\"futures\",\r\n         \"updateTime\":1576281599000\r\n      }\r\n   ]\r\n}";
	}
}