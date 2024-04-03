using Lab4Web.Controllers;
using Lab4Web.Services.Linq;
using Moq;

namespace WebTests;

[TestFixture]
public class TestLinqControllerTests
{
    [Test]
    public void GetMethod_ShouldCallService_Once()
    {
        //Arrage
        var mockLinqService = new Mock<ILinqService>();
        var testLinqController = new TestLinqController(mockLinqService.Object);

        //act
        testLinqController.Get(1);

        //assert
        mockLinqService.Verify(m=>m.Test1(1), Times.Once);
    }

    [Test]
    public void GetMethod_ShouldReturn_NumerOfPersons()
    {
        //Arrange
        var mockLinqService = new Mock<ILinqService>();
        mockLinqService.Setup(s => s.Test1(It.IsAny<int>())).Returns(2);

        var testLinqController = new TestLinqController(mockLinqService.Object);

        //Act
        var personCount = testLinqController.Get(20);

        //Assert
        Assert.AreEqual(2, personCount);
    }

    [Test]
    public void GetMethod_SouldCall_ServiceTest1Twice_And_Test2Once()
    {
        //Arrange
        var mockLinqService = new Mock<ILinqService>();
        var testLinqController = new TestLinqController(mockLinqService.Object);

        //Act
        testLinqController.GetMethod(10);

        //Assert
        mockLinqService.Verify(a=>a.Test1(It.IsAny<int>()), Times.Exactly(2));
        mockLinqService.Verify(b=>b.Test2(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }

    [Test]
    public void GetMethod_ShouldReturn_RightSumForPersonCount()
    {
        //Arrange
        var mockLinqService = new Mock<ILinqService>();
        mockLinqService.Setup(a=>a.Test1(It.IsAny<int>())).Returns(5);
        mockLinqService.Setup(b => b.Test2(It.IsAny<int>(), It.IsAny<int>())).Returns(12);

        var testLinqController = new TestLinqController(mockLinqService.Object);

        //Act
        ////Assert
        Assert.Throws<ArgumentException>(() => testLinqController.GetMethod(20));

        
    }
}