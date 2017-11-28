using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Model
{
	[Serializable]
	public class Block
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "timestamp")]
		public DateTime Timestamp { get; set; }

		[JsonProperty(PropertyName = "transactions")]
		public List<Transaction> Transactions { get; set; }

		[JsonProperty(PropertyName = "proof")]
		public int Proof { get; set; }

		[JsonProperty(PropertyName = "previousHash")]
		public byte[] PreviousHash { get; set; }
	}
}
