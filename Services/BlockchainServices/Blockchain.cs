using Havit.Extensions.DependencyInjection.Abstractions;
using Rada.BlockchainTurorial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	[Service(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
	public class Blockchain : IBlockchain
	{
		private const int MiningReward = 100000000;

		private readonly List<Block> chain = new List<Block>();
		private readonly List<Transaction> pendingTransaction = new List<Transaction>();

		private readonly IHashCalculator blockHashCalculator;
		private readonly IBlockCreator blockCreator;
		private readonly IProofValidator proofValidator;
		private readonly IBlockchainValidator blockchainValidator;

		public Blockchain(IBlockCreator blockCreator, IHashCalculator blockHashCalculator, IProofValidator proofValidator, IBlockchainValidator blockchainValidator)
		{
			this.blockCreator = blockCreator;
			this.blockHashCalculator = blockHashCalculator;
			this.proofValidator = proofValidator;
			this.blockchainValidator = blockchainValidator;
			
			if (chain.Count == 0)
			{
				Block firstBlock = blockCreator.CreateBlock(0, new List<Transaction>(), 0, null);
				chain.Add(firstBlock);
			}
		}

		public Block[] Chain => chain.ToArray();

		public void AddTransaction(Transaction transaction)
		{
			pendingTransaction.Add(transaction);
		}

		public Block CreateBlock(int currentProof)
		{
			Block lastBlock = GetLastBlock();
			byte[] lastBlockHash = blockHashCalculator.CalculateBlockHash(lastBlock);

			return CreateBlock(currentProof, lastBlockHash);
		}

		public Block CreateBlock(int currentProof, byte[] previousHash)
		{
			Block lastBlock = GetLastBlock();
			Block block = blockCreator.CreateBlock(lastBlock.Id + 1, pendingTransaction, currentProof, previousHash);

			pendingTransaction.Clear();
			chain.Add(block);

			return block;
		}

		public Block GetLastBlock()
		{
			return chain.LastOrDefault();
		}

		public int GetMiningReward()
		{
			return MiningReward;
		}

		public int GetProofOfWork(int lastProof)
		{
			int proof = 0;

			while (!proofValidator.IsProofValid(lastProof, proof))
			{
				proof += 1;
			}

			return proof;
		}

		public bool TryResolveConflicts(List<IBlockchain> neighborChains)
		{
			List<Block> newChain = null;
			int maxLength = chain.Count;

			for (int i = 0; i < neighborChains.Count; i++)
			{
				Block[] neighborChain = neighborChains[i].Chain;
				int length = neighborChain.Length;

				if ((neighborChain.Length > maxLength) && blockchainValidator.IsBlockchainValid(neighborChain))
				{
					maxLength = length;
					newChain = new List<Block>(neighborChain);
				}
			}

			if (newChain != null)
			{
				chain.Clear();
				chain.AddRange(newChain);
				pendingTransaction.Clear();
			}

			return (newChain != null);
		}
	}
}
