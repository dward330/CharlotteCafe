using System;

namespace OnlineCafe.Interfaces.IoC
{
  /// <summary>
  ///     A dependency resolver interface.
  ///     Example implementation:
  /// </summary>
  /// <example>The 'UnityDependencyResolver' implementation</example>
  public interface IDependencyResolver
  {
    /// <summary>
    ///     Registers one Type to another.
    /// </summary>
    /// <param name="typeFrom">The Type to map from.</param>
    /// <param name="typeTo">The Type to map to.</param>
    void Register(Type typeFrom, Type typeTo);

    /// <summary>
    ///     Registers a Type to an instance.
    /// </summary>
    /// <param name="typeFrom">The Type to map from.</param>
    /// <param name="instance">The instance to map to.</param>
    void Register(Type typeFrom, object instance);

    /// <summary>
    ///     Resolves the object registered to the given Type
    /// </summary>
    /// <param name="type">Type of object to get.</param>
    /// <returns>The object registered to Type T</returns>
    object Resolve(Type type);
  }
}
