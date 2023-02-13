using BinanceSDK.DTO;
using BinanceSDK.Private;

namespace BinanceSdkTest.Private
{
	[TestClass]
	public class PrivateRestRawTest
	{
		private PrivateRestRaw client = new PrivateRestRaw(Env.Access);


		[TestMethod]
		public async Task ShouldGetCoins()
		{
			var res = await client.GetDailyAccountSnapshotAsync(SnapshotType.SPOT);
			Assert.IsNotNull(res);
		}


		// TODO: Test the withdraw method in better way
		[TestMethod]
		public async Task ShouldTryWithdrawCoins()
		{
			await Assert.ThrowsExceptionAsync<Exception>(async () =>
			{
				await client.Withdraw("USDT", "fakeAddress", 0);
			});
		}
	}
}