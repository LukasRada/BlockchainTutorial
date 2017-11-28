using Rada.BlockchainTurorial.Model;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	public interface ITransactionCreator
	{
		Transaction CreateTransaction(string receiverAddress, string senderAddress, int value);
	}
}