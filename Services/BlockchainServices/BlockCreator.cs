﻿using Havit.Diagnostics.Contracts;
using Havit.Extensions.DependencyInjection.Abstractions;
using Havit.Services.TimeServices;
using Newtonsoft.Json;
using Rada.BlockchainTurorial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	[Service]
	public class BlockCreator : IBlockCreator
	{
		private readonly ITimeService timeService;
        private readonly IHashCalculator hashCalculator;

        public BlockCreator(ITimeService timeService, IHashCalculator hashCalculator)
		{
			this.timeService = timeService;
            this.hashCalculator = hashCalculator;
        }

		public Block CreateBlock(int id, List<Transaction> transactions, int proof, byte[] previousHash)
		{
			Contract.Requires<ArgumentNullException>(transactions != null);

            Block block = new Block
            {
                Id = id,
                Transactions = new List<Transaction>(transactions),
                Proof = proof,
                PreviousHash = previousHash,
                Timestamp = timeService.GetCurrentTime()
            };

            block.Hash = hashCalculator.CalculateBlockHash(block);

            return block;
        }
	}
}
