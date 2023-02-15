using BinanceSDK.Helpers.Request;

namespace BinanceSdkTest.Helpers
{
	[TestClass]
	public class RequestTest
	{
		[TestMethod]
		public void ShouldCreateQueryString()
		{
			var req = new TestReq();
			Assert.AreEqual("v1=7&v2=4", req.GetQueryString());
		}


		private class TestReq : Req
		{
			[Query("v1")]
			public int V1 = 7;

			[Query]
			public string v2 = "4";
		}
	}
}
