using NUnit.Framework;
using System.Linq;

namespace ArgumentsBuilder.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var args = new[] {
            "aparam",
            "-a",
            "aopt",
            "-b",
            "bopt",
            "bparam",
            "/c",
            "copt",
            };
            var parsed = Rksoftware.ArgumentsBuilder.ArgumentsBuilder.Parse(args);
            Assert.AreEqual(parsed.parameters.Count, 2);
            Assert.AreEqual(parsed.parameters.Skip(0).FirstOrDefault(), "aparam");
            Assert.AreEqual(parsed.parameters.Skip(1).FirstOrDefault(), "bparam");
            Assert.AreEqual(parsed.options.Count, 3);
            { Assert.AreEqual(parsed.options.TryGetValue("a", out var val) ? val : null, "aopt"); }
            { Assert.AreEqual(parsed.options.TryGetValue("b", out var val) ? val : null, "bopt"); }
            { Assert.AreEqual(parsed.options.TryGetValue("c", out var val) ? val : null, "copt"); }
        }
    }
}