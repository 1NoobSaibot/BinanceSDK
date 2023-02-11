using BinanceSDK.Private;
using Newtonsoft.Json;
using System.Text;

namespace BinanceSdkTest
{
	public static class Env
	{
		private const string _fileName = ".access.json";
		private static Access? _access = null;
		public static Access Access
		{
			get => _access ?? _InitAccess();
		}


		private static Access _InitAccess()
		{
			using (StreamReader reader = new StreamReader(_fileName, Encoding.UTF8))
			{
				string json = reader.ReadToEnd();
				var access = JsonConvert.DeserializeObject<Access>(json);
				_access = access;
				return access;
			}
		}
	}
}
