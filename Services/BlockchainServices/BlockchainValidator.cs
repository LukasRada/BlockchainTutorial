using Havit.Extensions.DependencyInjection.Abstractions;
using Rada.BlockchainTurorial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	[Service]
	public class BlockchainValidator : IBlockchainValidator
	{
		private readonly IHashCalculator hashCalculator;
		private readonly IProofValidator proofValidator;

		public BlockchainValidator(IHashCalculator hashCalculator, IProofValidator proofValidator)
		{
			this.hashCalculator = hashCalculator;
			this.proofValidator = proofValidator;
		}

		public bool IsBlockchainValid(Block[] chain)
		{
			Block lastBlock = chain.LastOrDefault();

			Block[] chainWithoutGenesisBlock = chain.Skip(1).ToArray();

			bool hasMatchByHash = chainWithoutGenesisBlock.All(block => block.PreviousHash == hashCalculator.CalculateBlockHash(lastBlock));

			bool hasMatchByProof = chainWithoutGenesisBlock.All(block => proofValidator.IsProofValid(lastBlock.Proof, block.Proof));

			return (hasMatchByHash && hasMatchByProof);
		}
	}
}
