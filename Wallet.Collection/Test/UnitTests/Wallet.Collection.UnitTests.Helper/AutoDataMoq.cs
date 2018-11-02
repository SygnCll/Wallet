using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;


namespace Wallet.Collection.UnitTests.Helper
{
    public class AutoDataMoq : AutoDataAttribute
    {
        public AutoDataMoq() : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
        public AutoDataMoq(Type type, params object[] parameters) : this()
        {
            object obj = Activator.CreateInstance(type, parameters);
            base.Fixture.Customize(obj as ICustomization);
        }
    }
}
