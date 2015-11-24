using System.Linq;
using NUnit.Framework;
using UamTTA.Tools;

namespace UamTTA.Tests.Tools
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void ToElementsString_Should_Return_Brace_Wrapped_Element_For_Singleton_Enumeration()
        {
            var oneElement = Enumerable.Repeat("An object", 1);

            var actual = oneElement.ToElementsString();

            Assert.AreEqual("[An object]", actual);
        }

        [Test]
        public void ToElementsString_Should_Return_Braced_Wrapped_Comma_Delimited_Elements_For_Enumeration()
        {
            var someEnumeration = new object[] {"One", "Two", 3};

            var actual = someEnumeration.ToElementsString();

            Assert.AreEqual("[One, Two, 3]", actual);
        }

        [Test]
        public void ToElementsString_Should_Return_Empty_Braces_For_Empty_Enumeration()
        {
            var empty = Enumerable.Empty<object>();

            var actual = empty.ToElementsString();

            Assert.AreEqual("[]", actual);
        }

        [Test]
        public void ToElementsString_Should_Return_Empty_Braces_For_Null_Value()
        {
            var actual = EnumerableExtensions.ToElementsString<object>(null);

            Assert.AreEqual("[]", actual);
        }
    }
}