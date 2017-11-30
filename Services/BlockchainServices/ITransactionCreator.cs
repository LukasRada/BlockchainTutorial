using Rada.BlockchainTurorial.Model;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface ITransactionCreator
	{
		/// <summary>
		/// Creates transaction.
		/// </summary>
		Transaction CreateTransaction(string receiverAddress, string senderAddress, int value);
	}
}