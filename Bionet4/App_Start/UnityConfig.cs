using System;
using Unity;

namespace Bionet4
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static partial class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion
    }
}