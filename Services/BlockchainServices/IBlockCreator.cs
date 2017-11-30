using Rada.BlockchainTurorial.Model;
using System.Collections.Generic;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IBlockCreator
	{
		/// <summary>
		/// Creates block with pending transaction waiting to be confirmed and with previous block hash.
		/// </summary>
		Block CreateBlock(int id, List<Transaction> transactions, int proof, byte[] previousHash);
	}
}