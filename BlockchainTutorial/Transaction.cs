using Newtonsoft.Json;
using System;

namespace Rada.BlockchainTurorial.Model
{
	[Serializable]
	public class Transaction
	{
		[JsonProperty(PropertyName = "senderAddress")]
		public string SenderAddress { get; set; }

		[JsonProperty(PropertyName = "receiverAddress")]
		public string ReceiverAddress { get; set; }

		[JsonProperty(PropertyName = "value")]
		public int Value { get; set; }
	}
}