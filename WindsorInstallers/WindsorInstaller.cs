using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Havit.Extensions.DependencyInjection.Abstractions;
using Havit.Extensions.DependencyInjection.CastleWindsor;
using Havit.Services;
using Havit.Services.TimeServices;
using Rada.BlockchainTurorial.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rada.BlockhainTurorial.WindsorInstallers
{
    public static class WindsorInstaller
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static IWindsorContainer ConfigureForTests(this IWindsorContainer container)
		{
			InstallConfiguration installConfiguration = new InstallConfiguration
			{
				ServiceProfiles = new[] { ServiceAttribute.DefaultProfile },
				ScopedLifestyle = lf => lf.PerThread
			};

			return container.ConfigureForAll(installConfiguration);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static IWindsorContainer ConfigureForNode(this IWindsorContainer container)
		{
			InstallConfiguration installConfiguration = new InstallConfiguration
			{
				ServiceProfiles = new[] { ServiceAttribute.DefaultProfile },
				ScopedLifestyle = lf => lf.PerThread
			};

			return container.ConfigureForAll(installConfiguration);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IWindsorContainer ConfigureForAll(this IWindsorContainer container, InstallConfiguration installConfiguration)
		{
			// umožní resolvovat i kolekce závislostí - IEnumerable<IDependency>
			container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

			// facilities
			container.AddFacility<TypedFactoryFacility>();
			container.Register(Component.For(typeof(IServiceFactory<>)).AsFactory());

			InstallHavitServices(container);

			container.InstallByServiceAttibute(typeof(BlockchainTurorial.Services.Properties.AssemblyInfo).Assembly, installConfiguration.ServiceProfiles, installConfiguration.ScopedLifestyle);

			return container;
		}

		private static void InstallHavitServices(IWindsorContainer container)
		{
			// HAVIT .NET Framework Extensions
			container.Register(Component.For<ITimeService>().ImplementedBy<ApplicationTimeService>().LifestyleSingleton());
		}
	}
}
