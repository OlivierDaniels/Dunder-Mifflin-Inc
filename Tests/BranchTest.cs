using consoleapp.Models;

namespace Tests
{
    [TestClass]
    [TestCategory("Models")]
    public class BranchTest
    {
        [TestMethod]
        public void Branch_Constructor_CreatesCorrectInstance()
        {
            //Arrange
            Address address = new Address("Palm Street","Columbus","Ohio", "43201");
            Branch branch = new Branch(11,"Columbus","Olivier Daniels",address);

            //Act
            branch.Id = 15;

            //Assert
            Assert.IsNotNull(branch);
            Assert.AreEqual(15, branch.Id);
            Assert.AreEqual("Columbus",branch.Name);
            Assert.AreEqual("Olivier Daniels", branch.Manager);
            Assert.AreEqual(address, branch.Address);
        }
    }
}