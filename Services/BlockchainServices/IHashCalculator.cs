using Rada.BlockchainTurorial.Model;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IHashCalculator
	{
		/// <summary>
		/// Calculates hash of block.
		/// </summary>
		/// <param name="block"></param>
		/// <returns></returns>
		byte[] CalculateBlockHash(Block block);

		/// <summary>
		/// Calculates hash of proof.
		/// </summary>
		byte[] CalculateProofHash(string lastProof, string proof);
	}
}