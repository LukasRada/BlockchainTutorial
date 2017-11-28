using Havit.Extensions.DependencyInjection.Abstractions;
using Rada.BlockchainTurorial.Model;
using Rada.BlockchainTurorial.Services.BlockchainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.Mining
{
	[Service]
	public class Miner : IMiner
	{
		private readonly IBlockchain blockChain;
		private readonly ITransactionCreator transactionCreator;
		private readonly IBlockCreator blockCreator;

		public Miner(IBlockchain blockChain, ITransactionCreator transactionCreator, IBlockCreator blockCreator)
		{
			this.blockChain = blockChain;
			this.transactionCreator = transactionCreator;
			this.blockCreator = blockCreator;
		}

		public Block Mine(string receiverAddress)
		{
			Block lastBlock = blockChain.GetLastBlock();
			int currentProof = blockChain.GetProofOfWork(lastBlock.Proof);

			Transaction transaction = transactionCreator.CreateTransaction(receiverAddress, String.Empty, blockChain.GetMiningReward());
			blockChain.AddTransaction(transaction);

			Block block = blockChain.CreateBlock(currentProof);

			return block;
		}

		public Task<Block> MineAsync(string receiverAddress)
		{
			return Task.Run(() => Mine(receiverAddress));
		}
	}
}
