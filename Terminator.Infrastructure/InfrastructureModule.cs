namespace Terminator.Infrastructure
{
    using Autofac;
    using Terminator.Core.Repositories;
    using Terminator.Infrastructure.Data.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The DI module
    /// </summary>
    public class InfrastructureModule : Module
    {
        /// <summary>
        /// Loads the container modules
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder
              .RegisterType<UserRepository>()
              .As<IUserRepository>()
              .InstancePerLifetimeScope();
        }
    }    
}
