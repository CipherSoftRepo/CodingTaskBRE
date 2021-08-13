using NUnit.Framework;

namespace CodingTaskBRE.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

     
        [Test]
        public void ShouldReturnBookSlipOnly()
        {
            var result = CodingTaskBRE.OrderSystem.GetProduct(new string[] { "Book", "Random" });
            Assert.AreEqual("Random", result.Name);
            Assert.AreEqual("Generated a packing slip for shipping.", result.Operations[0]);
            Assert.AreEqual("Commission payment to the agent", result.Operations[1]);
            Assert.AreEqual("Create a duplicate packing slip for the royalty department.", result.Operations[2]);
            Assert.AreEqual(3, result.Operations.Count);

        }

        [Test]
        public void ShouldReturnOther()
        {
            var result = CodingTaskBRE.OrderSystem.GetProduct(new string[] { "other", "Random" });
            Assert.AreEqual("Random", result.Name);
            Assert.AreEqual("Generated a packing slip for shipping.", result.Operations[0]);
            Assert.AreEqual("Commission payment to the agent", result.Operations[1]);
            Assert.AreEqual(2, result.Operations.Count);

            result = OrderSystem.GetProduct(new string[] { "random", "Random" });
            Assert.AreEqual("Random", result.Name);
            Assert.AreEqual("Generated a packing slip for shipping.", result.Operations[0]);
            Assert.AreEqual("Commission payment to the agent", result.Operations[1]);
            Assert.AreEqual(2, result.Operations.Count);
        }

        [Test]
        public void ShouldReturnVideoSlipOnly()
        {
            var result = OrderSystem.GetProduct(new string[] { "video", "Random" });
            Assert.AreEqual("Random", result.Name);
            Assert.AreEqual("Generated a packing slip.", result.Operations[0]);
            Assert.AreEqual(1, result.Operations.Count);

        }

        [Test]
        public void ShouldReturnVideoLearningToSkiSlipOnly()
        {
            var result = OrderSystem.GetProduct(new string[] { "video", "Learning To Ski" });
            Assert.AreEqual("Learning To Ski", result.Name);
            Assert.AreEqual("Generated a packing slip.", result.Operations[0]);
            Assert.AreEqual("'First Aid' video added to the packing slip", result.Operations[1]);
            Assert.AreEqual(2, result.Operations.Count);
        }

        [Test]
        public void ShouldReturnUpgradeSlipOnly()
        {
            var result = OrderSystem.GetProduct(new string[] { "Upgrade", "Random" });
            Assert.IsNull(result.Name);
            Assert.AreEqual("Generated a packing slip.", result.Operations[0]);
            Assert.AreEqual("Apply the upgrade", result.Operations[1]);
            Assert.AreEqual("Mail Sent", result.Operations[2]);
            Assert.AreEqual(3, result.Operations.Count);

        }

        [Test]
        public void ShouldReturnMembershipSlip()
        {
            var result = OrderSystem.GetProduct(new string[] { "Membership", "Random" });
            Assert.IsNull(result.Name);
            Assert.AreEqual("Generated a packing slip.", result.Operations[0]);
            Assert.AreEqual("Activate that membership", result.Operations[1]);
            Assert.AreEqual("Mail Sent", result.Operations[2]);
            Assert.AreEqual(3, result.Operations.Count);

        }


    }
}