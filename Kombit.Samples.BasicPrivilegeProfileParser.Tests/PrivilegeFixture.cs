#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

#endregion

namespace Kombit.Samples.BasicPrivilegeProfileParser.Tests
{
    /// <summary>
    ///     Represent a fixture for testing basic privilege profile
    /// </summary>
    public class PrivilegeFixture : Fixture
    {
        /// <summary>
        ///     Initialize PrivilegeFixture
        /// </summary>
        public PrivilegeFixture()
        {
            Customize(new AutoMoqCustomization());
        }

        /// <summary>
        ///     Freez many generic object types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal IEnumerable<T> FreezeMany<T>()
        {
            var items = this.CreateMany<T>().ToList();
            this.Inject<IEnumerable<T>>(items);
            return items;
        }

        /// <summary>
        ///     Freez generic object type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal T Freeze<T>()
        {
            var item = this.Create<T>();
            this.Inject<T>(item);
            return item;
        }

        /// <summary>
        ///     Setup mock action with generic type object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mockAction"></param>
        /// <returns></returns>
        internal PrivilegeFixture SetupMoq<T>(Action<Mock<T>> mockAction) where T : class
        {
            Customize<T>(ob => ob.FromFactory(() =>
            {
                var td = this.Create<Mock<T>>();
                mockAction(td);
                return td.Object;
            }).OmitAutoProperties());

            return this;
        }

        /// <summary>
        ///     Initialize PrivilegeFixture with certificate stuff
        /// </summary>
        /// <returns></returns>
        internal PrivilegeFixture WithCertificateStuff()
        {
            this.Register(() => StoreLocation.CurrentUser);
            this.Register(() => StoreName.My);
            this.Register(() => X509FindType.FindByThumbprint);
            Customize<X509Certificate2>(ob => ob.OmitAutoProperties());

            return this;
        }
    }
}