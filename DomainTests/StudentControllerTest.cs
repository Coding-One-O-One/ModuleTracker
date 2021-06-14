using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleTracker.Controllers;
using ModuleTracker.Data;
using Xunit;

namespace DomainTests
{
    [TestClass]
    public class StudentControllerTest
    {
        [Fact]
        //UnitOfWork_StateUnderTest_ExpectedBehavior
        public void GetStudentById_WithUnexistingItem_RetuenNotFound()
        {
            //Arrage
            var stubRepo = new MockRepo();
            //var mapper = new ...
            //var controller = new StudentController(stubRepo, mapper);

            //Act

            //Assert
        }
    }
}
