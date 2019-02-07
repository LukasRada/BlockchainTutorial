using Newtonsoft.Json;
using System;

namespace Rada.BlockchainTurorial.Model
{
	[Serializable]
	public class Transaction
	{
		public string SenderAddress { get; set; }
        
		public string ReceiverAddress { get; set; }
        
		public int Value { get; set; }
	}
}