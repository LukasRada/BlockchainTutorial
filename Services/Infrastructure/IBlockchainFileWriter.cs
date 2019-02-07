using Rada.BlockchainTurorial.Model;

namespace Rada.BlockchainTurorial.Services.Infrastructure
{
    public interface IBlockchainFileWriter
    {
        void WriteBlocksToFile(Block[] blocks);
    }
}