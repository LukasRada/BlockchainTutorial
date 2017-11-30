namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface IProofValidator
	{
		/// <summary>
		/// Returns true if proof is valid.
		/// </summary>
		bool IsProofValid(int lastProof, int proof);
	}
}