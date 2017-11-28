using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityDriven.Inferno;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	[Service]
	public class ProofValidator : IProofValidator
	{
		private readonly IHashCalculator hashCalculator;

		public ProofValidator(IHashCalculator hashCalculator)
		{
			this.hashCalculator = hashCalculator;
		}

		public bool IsProofValid(int lastProof, int proof)
		{
			byte[] guessHash = hashCalculator.CalculateProofHash(lastProof.ToString(), proof.ToString());

			return guessHash.Take(3).All(byteItem => byteItem == 0x00);
		}
	}
}
