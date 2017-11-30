using Rada.BlockchainTurorial.Model;
using System.Collections.Generic;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IBlockchain
	{
		/// <summary>
		/// Chain of blocks.
		/// </summary>
		Block[] Chain { get; }

		/// <summary>
		/// Returns last block in chain.
		/// </summary>
		Block GetLastBlock();

		/// <summary>
		/// Creates block by computed proof.
		/// </summary>
		Block CreateBlock(int currentProof);

		/// <summary>
		/// Gets proof of work by last proof of work.
		/// </summary>
		int GetProofOfWork(int lastProof);

		/// <summary>
		/// Add pending transaction.
		/// </summary>
		void AddTransaction(Transaction transaction);

		/// <summary>
		/// Tries to resolve chain conflict
		/// </summary>
		bool TryResolveConflicts(List<IBlockchain> neighborChains);

		/// <summary>
		/// Gets mining reward.
		/// </summary>
		int GetMiningReward();
	}
}