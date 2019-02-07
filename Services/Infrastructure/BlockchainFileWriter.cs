using Havit.Extensions.DependencyInjection.Abstractions;
using Newtonsoft.Json;
using Rada.BlockchainTurorial.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Services.Infrastructure
{
    [Service]
    public class BlockchainFileWriter : IBlockchainFileWriter
    {
        public void WriteBlocksToFile(Block[] blocks)
        {
            string serializedBlocks = JsonConvert.SerializeObject(blocks);

            string path = @"d:\BlockchainTutorial\MyTest.json";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(serializedBlocks);
            }
        }
    }
}
