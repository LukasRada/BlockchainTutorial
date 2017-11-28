using Rada.BlockchainTurorial.Model;
using System.Collections.Generic;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IBlockCreator
	{
		Block CreateBlock(int id, List<Transaction> transactions, int proof, byte[] previousHash);
	}
}