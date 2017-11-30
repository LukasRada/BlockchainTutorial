using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rada.BlockchainTurorial.Model;
using SecurityDriven.Inferno;
using Newtonsoft.Json;
using Havit.Diagnostics.Contracts;
using Havit.Extensions.DependencyInjection.Abstractions;
using System.Security.Cryptography;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	[Service]
	public class HashCalculator : IHashCalculator
	{
		private readonly Func<SHA256> hashFactory;

		public HashCalculator()
		{
			hashFactory = SecurityDriven.Inferno.Hash.HashFactories.SHA256;
		}

		public byte[] CalculateBlockHash(Block block)
		{
			Contract.Requires<ArgumentNullException>(block != null);

			string lastBlockAsString = JsonConvert.SerializeObject(block);
			byte[] lastBlockAsBytes = Encoding.UTF8.GetBytes(lastBlockAsString);

			byte[] lastBlockAsHash = hashFactory().ComputeHash(lastBlockAsBytes);

			return lastBlockAsHash;
		}

		public byte[] CalculateProofHash(string lastProof, string proof)
		{
			Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(lastProof));
			Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(proof));

			long guessNumber = Int64.Parse($"{lastProof}{proof}");
			byte[] guess = BitConverter.GetBytes(guessNumber).Reverse().ToArray();
			byte[] guessHash = hashFactory().ComputeHash(guess);

			return guessHash;
		}
	}
}
