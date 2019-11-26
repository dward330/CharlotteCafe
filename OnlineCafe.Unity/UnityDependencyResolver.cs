using System;
using Unity;
using OnlineCafe.Interfaces.IoC;
using Unity.RegistrationByConvention;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Exceptions;

namespace OnlineCafe.Unity
{
  /// <summary>
  ///     A unity implementation of the IDependencyResolver
  /// </summary>
  /// <seealso cref="OnlineCafe.Interfaces.IoC.IDependencyResolver" />
  public class UnityDependencyResolver : IServiceProvider
  {
    /// <summary>
    ///     The unity container
    /// </summary>
    private readonly UnityContainer _unityContainer;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnityDependencyResolver" /> class.
    /// </summary>
    public UnityDependencyResolver()
    {
      this._unityContainer = new UnityContainer();
    }

    public IUnityContainer GetContainer()
    {
      return _unityContainer;
    }

    public void RegisterAllTypes(IEnumerable<Type> assemblies)
    {
      _unityContainer.RegisterTypes(assemblies,
            WithMappings.FromMatchingInterface,
            WithName.Default,
            WithLifetime.ContainerControlled);
    }

    public object GetService(Type serviceType)
    {
      try
      {
        return _unityContainer.Resolve(serviceType);
      }
      catch (ResolutionFailedException)
      {
        return null;
      }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      try
      {
        return _unityContainer.ResolveAll(serviceType);
      }
      catch (ResolutionFailedException)
      {
        return new List<object>();
      }
    }

    public object Resolve(Type type)
    {
      return this._unityContainer?.Resolve(type);
    }

    /// <summary>
    ///     Registers one Type to another.
    /// </summary>
    /// <param name="typeFrom">The Type to map from.</param>
    /// <param name="typeTo">The Type to map to.</param>
    public void Register(Type typeFrom, Type typeTo)
    {
      this._unityContainer.RegisterType(typeFrom, typeTo);
    }

    /// <summary>
    ///     Registers a Type to an instance.
    /// </summary>
    /// <param name="typeFrom">The Type to map from.</param>
    /// <param name="instance">The instance to map to.</param>
    public void Register(Type typeFrom, object instance)
    {
      AssertTypesAreAssignable(typeFrom, instance.GetType());
      this._unityContainer.RegisterInstance(typeFrom, instance);
    }

    /// <summary>
    /// Checks the types to ensure they are compatible.
    /// </summary>
    /// <param name="from">The source type.</param>
    /// <param name="to">The target type.</param>
    /// <exception cref="ArgumentException">The target type cannot be assigned from the source type.</exception>
    private static void AssertTypesAreAssignable(Type from, Type to)
    {
      if (!from.IsAssignableFrom(to))
      {
        throw new ArgumentException("The target type cannot be assigned from the source type.");
      }
    }
    public void Dispose()
    {
      Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
      _unityContainer.Dispose();
    }
  }
}
