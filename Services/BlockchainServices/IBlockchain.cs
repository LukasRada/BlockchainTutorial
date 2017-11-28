using Rada.BlockchainTurorial.Model;
using System.Collections.Generic;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IBlockchain
	{
		Block GetLastBlock();
		Block CreateBlock(int currentProof);
		int GetProofOfWork(int lastProof);
		void AddTransaction(Transaction transaction);
		bool ResolveConflicts(List<List<Block>> neighborChains);
		int GetMiningReward();
	}
}