namespace Rada.BlockchainTurorial.Model
{
	public class Transaction
	{
		public string SenderAddress { get; set; }

		public string ReceiverAddress { get; set; }

		public int Value { get; set; }
	}
}