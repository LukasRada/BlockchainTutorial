using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockhainTurorial.Node
{
	public class Options
	{
		[VerbOption("ReceiverAddress", HelpText = "Add file contents to the index.")]
		public string ReceiverAddress { get; set; }
	}
}
