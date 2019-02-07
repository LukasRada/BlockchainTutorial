using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rada.BlockchainTurorial.Services.BlockchainServices;
using Rada.BlockchainTurorial.Services.Mining;
using Rada.BlockchainTurorial.Model;
using System.IO;
using Rada.BlockchainTurorial.Services.Infrastructure;

namespace Rada.BlockchainTurorial.Tests
{
	[TestClass]
	public class MinerTests : TestBase
	{
		[TestMethod]
		public void Miner_Mine()
		{
            // BLOCKCHAIN WITH GENESIS BLOCK
            IBlockchain blockchain = Container.Resolve<IBlockchain>();
            
            IMiner miner = Container.Resolve<IMiner>();
            IBlockchainFileWriter blockchainFileWriter  = Container.Resolve<IBlockchainFileWriter>();

            // TRANSACTIONS
            blockchain.AddTransaction(new Transaction { ReceiverAddress = "FRANTA", SenderAddress = "PEPA", Value = 100 });
            blockchain.AddTransaction(new Transaction { ReceiverAddress = "FRANTA", SenderAddress = "JÁRA", Value = 100 });
            blockchain.AddTransaction(new Transaction { ReceiverAddress = "FRANTA", SenderAddress = "VÉNA", Value = 100 });

            #region BLOCK #1

            Block blockOne = miner.Mine("MY_REWARD_FAKE_ADDRESS");
            Block lastBlock = blockchain.GetLastBlock();

            Assert.AreEqual(1, blockOne.Id);
			Assert.AreEqual(4, blockOne.Transactions.Count);
            Assert.AreEqual(blockchain.Chain[0].Hash, blockOne.PreviousHash);

            #endregion

            // TRANSACTIONS
            blockchain.AddTransaction(new Transaction { ReceiverAddress = "PEPA", SenderAddress = "JÁRA", Value = 50 });
            blockchain.AddTransaction(new Transaction { ReceiverAddress = "VÉNA", SenderAddress = "PEPA", Value = 20 });
            blockchain.AddTransaction(new Transaction { ReceiverAddress = "PEPA", SenderAddress = "FRANTA", Value = 10 });

            #region BLOCK #2

            Block blockTwo = miner.Mine("MY_REWARD_FAKE_ADDRESS");
            lastBlock = blockchain.GetLastBlock();
            
            Assert.AreEqual(2, blockTwo.Id);
			Assert.AreEqual(4, blockTwo.Transactions.Count);
            Assert.AreEqual(blockchain.Chain[1].Hash, blockTwo.PreviousHash);

            #endregion

            // ASSERT BLOCK CHAINING

            Assert.AreEqual(blockchain.Chain[0].Hash, blockchain.Chain[1].PreviousHash);
            Assert.AreEqual(blockchain.Chain[1].Hash, blockchain.Chain[2].PreviousHash);

            blockchainFileWriter.WriteBlocksToFile(blockchain.Chain);
        }
	}
}
