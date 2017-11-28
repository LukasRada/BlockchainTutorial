using Rada.BlockchainTurorial.Model;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.Mining
{
	public interface IMiner
	{
		Block Mine(string receiverAddress);
		Task<Block> MineAsync(string receiverAddress);
	}
}