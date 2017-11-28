using Castle.Windsor;
using Rada.BlockhainTurorial.WindsorInstallers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockchainTurorial.Tests
{
	/// <summary>
	/// Bázový třída pro testy.
	/// Zpřístupňuje nakonfigurovaný DI container.
	/// </summary>
	public class TestBase : IDisposable
	{
		protected IWindsorContainer Container { get; private set; }

		public TestBase()
		{
			IWindsorContainer container = new WindsorContainer();
			container.ConfigureForTests();

			this.Container = container;
		}

		public void Dispose()
		{
			this.Container.Dispose();
		}
	}
}
