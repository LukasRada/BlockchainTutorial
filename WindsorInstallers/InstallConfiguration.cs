using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Registration.Lifestyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockhainTurorial.WindsorInstallers
{
	internal class InstallConfiguration
	{
		public Func<LifestyleGroup<object>, ComponentRegistration<object>> ScopedLifestyle { get; set; }
		public string[] ServiceProfiles { get; set; }
	}
}
