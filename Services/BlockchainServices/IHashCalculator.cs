using Rada.BlockchainTurorial.Model;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IHashCalculator
	{
		byte[] CalculateBlockHash(Block block);
		byte[] CalculateProofHash(string lastProof, string proof);
	}
}