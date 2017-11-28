using Rada.BlockchainTurorial.Model;
using System.Collections.Generic;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IBlockchainValidator
	{
		bool IsBlockchainValid(List<Block> chain);
	}
}