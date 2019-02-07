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
		public int Id { get; set; }
        
		public DateTime Timestamp { get; set; }
        
		public List<Transaction> Transactions { get; set; }
        
		public int Proof { get; set; }
        
        [JsonConverter(typeof(HexStringJsonConverter))]
        public byte[] PreviousHash { get; set; }
        
        [JsonConverter(typeof(HexStringJsonConverter))]
        public byte[] Hash { get; set; }
    }
}
