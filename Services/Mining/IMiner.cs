using Rada.BlockchainTurorial.Model;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.Mining
{
	public interface IMiner
	{
		/// <summary>
		/// Mine blocks and receive reward to address.
		/// </summary>
		Block Mine(string receiverAddress);

		/// <summary>
		/// Mine blocks and receive reward to address asynchronously.
		/// </summary>
		Task<Block> MineAsync(string receiverAddress);
	}
}