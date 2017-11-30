using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rada.BlockchainTurorial.Services.BlockchainServices;
using Rada.BlockchainTurorial.Services.Mining;
using Rada.BlockchainTurorial.Model;

namespace Rada.BlockchainTurorial.Tests
{
	[TestClass]
	public class MinerTests : TestBase
	{
		[TestMethod]
		public void Miner_Mine_TwoBlocks()
		{
			IMiner miner = Container.Resolve<IMiner>();

			Block blockOne = miner.Mine("FAKE_ADDRESS");

			Assert.AreEqual(1, blockOne.Id);
			Assert.AreEqual(1, blockOne.Transactions.Count);

			Block blockTwo = miner.Mine("FAKE_ADDRESS");

			Assert.AreEqual(2, blockTwo.Id);
			Assert.AreEqual(1, blockTwo.Transactions.Count);
		}
	}
}
