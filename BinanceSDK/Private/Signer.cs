using System.Security.Cryptography;
using System.Text;

namespace BinanceSDK.Private
{
	internal class SignerHmac : IDisposable
	{
		private readonly HMACSHA256 hmacsha256;


		public SignerHmac(string secret)
		{
			hmacsha256 = new HMACSHA256(
				Encoding.UTF8.GetBytes(secret)
			);
		}


		public void Dispose()
		{
			hmacsha256.Dispose();
		}


		public string Sign(string payload)
		{
			byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
			byte[] hash = hmacsha256.ComputeHash(payloadBytes);
			return BitConverter
				.ToString(hash)
				.Replace("-", string.Empty)
				.ToLower();
		}
	}
}
