﻿using BinanceSDK.Helpers;
using Newtonsoft.Json;

namespace BinanceSDK.DTO.V1
{
	public class Network
	{
		[JsonProperty("addressRegex")]
    public string? AddressRegex;

    [JsonProperty("coin")]
    public string? CoinName;

    [JsonProperty("depositDesc")]
    public string? DepositDescription;

    [JsonProperty("depositEnable")]
    public bool IsDepositEnabled;

    [JsonProperty("isDefault")]
    public bool IsDefault;

    [JsonProperty("memoRegex")]
    public string? MemoRegex;

    [JsonProperty("minConfirm")]
    public int MinConfirmations;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("network")]
    public string? ProtocolName;

    // This is a verb for bool field... Binance, can you fix it?
    [JsonProperty("resetAddressStatus")]
    public bool ResetAddressStatus;

    [JsonProperty("specialTips")]
    public string? SpecialTips;

    [JsonProperty("unLockConfirm")]
    public int UnlockConfirmations;

    [JsonProperty("withdrawDesc")]
    public string? WithdrawDescription;

    [JsonProperty("withdrawEnable")]
    public bool IsWithdrawEnable;

    /// <summary>
    /// Fixed Withdrawal Fee
    /// </summary>
    [JsonProperty("withdrawFee")]
    public decimal WithdrawFee;

    // TODO: It seems to be a TickSize value
    [JsonProperty("withdrawIntegerMultiple")]
    public decimal WithdrawIntegerMultiple;

    [JsonProperty("withdrawMax")]
    public decimal MaxWithdrawAmount;

    [JsonProperty("withdrawMin")]
    public decimal MinWithdrawAmount;

    /// <summary>
    /// If the coin needs to provide memo to withdraw
    /// </summary>
    [JsonProperty("sameAddress")]
    public bool IsSameAddress;

    [JsonProperty("estimatedArrivalTime")]
    public int EstimatedArrivalTime;

    [JsonProperty("busy")]
    public bool IsBusy;


    public int GetWithdrawPrecision()
    {
      return WithdrawIntegerMultiple.TickSizeToPrecision();
    }
	}
}
