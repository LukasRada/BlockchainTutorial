using Havit.Extensions.DependencyInjection.Abstractions;
using Rada.BlockchainTurorial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.BlockchainServices
{
	[Service]
	public class TransactionCreator : ITransactionCreator
	{
		public Transaction CreateTransaction(string receiverAddress, string senderAddress, int value)
		{
			return new Transaction
			{
				ReceiverAddress = receiverAddress,
				SenderAddress = senderAddress,
				Value = value
			};
		}
	}
}
