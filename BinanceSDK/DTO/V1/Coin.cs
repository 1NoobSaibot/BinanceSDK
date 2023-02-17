using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1
{
	public class Coin
	{
		[JsonProperty("coin")]
    public string? ShortName;

    [JsonProperty("depositAllEnable")]
    public bool depositAllEnable;

    // TODO: FreeAmount?
    [JsonProperty("free")]
    public decimal Free;

    [JsonProperty("freeze")]
    public decimal Freeze;

    // TODO: What is that??
    [JsonProperty("ipoable")]
    public decimal Ipoable;

    // TODO: ???
    [JsonProperty("ipoing")]
    public decimal Ipoint;

    // Of cource!!!
    [JsonProperty("isLegalMoney")]
    public bool IsLegalMoney;

    // TODO: Locked And Frozen?
    [JsonProperty("locked")]
    public decimal Locked;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("networkList")]
    public Network[]? Networks;

    [JsonProperty("storage")]
    public decimal Storage;

    [JsonProperty("trading")]
    public bool CanTrading;

    [JsonProperty("withdrawAllEnable")]
    public bool AllWithdrawEnable;

    // TODO: In process (withdrawing)?
    [JsonProperty("withdrawing")]
    public decimal Withdrawing;
	}
}
