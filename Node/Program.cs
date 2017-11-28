using Castle.Windsor;
using Rada.BlockchainTurorial.Services.BlockchainServices;
using Rada.BlockchainTurorial.Services.Mining;
using Rada.BlockhainTurorial.WindsorInstallers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockhainTurorial.Node
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Options options = new Options();
			if (CommandLine.Parser.Default.ParseArguments(args, options))
			{
				IWindsorContainer container = new WindsorContainer();
				container.ConfigureForNode();

				if (!String.IsNullOrEmpty(options.ReceiverAddress))
				{
					// mine
				}
				else
				{
					// sync
				}
			}
		}		
	}
}
