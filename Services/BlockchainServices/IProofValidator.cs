namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IProofValidator
	{
		bool IsProofValid(int lastProof, int proof);
	}
}