using Rada.BlockchainTurorial.Model;
using System.Collections.Generic;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IBlockchainValidator
	{
		/// <summary>
		/// Returns true if blockchain is valid.
		/// </summary>
		bool IsBlockchainValid(Block[] chain);
	}
}