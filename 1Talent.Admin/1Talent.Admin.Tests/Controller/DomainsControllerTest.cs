using System;
using System.Collections.Generic;
using System.Text;
using _1Talent.Admin.BLL.Interfaces;
using _1Talent.Admin.Controllers;
using _1Talent.Admin.DTO;
using Moq;
using Xunit;
namespace _1Talent.Admin.Tests.Controller
{
    public class DomainsControllerTest
    {
        private readonly Mock<IDomain> _idomain;

        public DomainsControllerTest()
        {
            var repo = new MockRepository(MockBehavior.Default);
            _idomain = repo.Create<IDomain>();
        }
        [Fact]
        public void To_Check_Get_Return_List_Or_Not()
        {
            // Arrange
            _idomain.Setup(x => x.ListofDomain()).Returns(new List<DomainModel>());

            // Act
            var controller = new DomainsController(_idomain.Object);
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void To_Check_Get_Return_ListById_Or_Not(bool i)
        {
            // Arrange
            _idomain.Setup(x => x.GetDomainFromId(It.IsAny<DomainModel>())).Returns(GetDomain());

            // Act
            var controller = new DomainsController(_idomain.Object);
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
        }
        private DomainModel GetDomain()
        {
            var byId = new DomainModel{ DomainId = 8 };
            return new DomainModel();
        }
        private List<DomainModel> GetDtoList(int members)
        {
            var list = new List<DomainModel>();

            for (int i = 1; i >= members; i++)
            {
                list.Add(new DomainModel());
            }

            return list;
        }
    }
}
