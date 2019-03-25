using _1Talent.Admin.BLL.Domain;
using _1Talent.Admin.DAL.Context;

using _1Talent.Admin.DTO;
using Moq;
using OneAuthorityManagementConsole.Tests.Shared;
using OneRPP.Restful.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _1Talent.Admin.Tests.BLL
{
    public class DomainTest
    {
        private readonly Mock<DomainContext> _domainContext;


        public DomainTest()
        {
            var setupTest = new SetupTest();
            var serviceProvider = setupTest.Setup();
            _domainContext = new Mock<DomainContext>(serviceProvider);

        }

        [Fact]
        public void To_Check_GetDomains_Method()
        {
            //Arrange
            var mockRepository = new Mock<DaoRepository<DomainModel>>();
            mockRepository.Setup(x => x.SelectAll()).Returns(new List<DomainModel>());
            _domainContext.Setup(x => x.DaoRepository).Returns(mockRepository.Object);

            //Act
            var bll = new Domain(_domainContext.Object);
            var result = bll.ListofDomain();

            //Assert
            Assert.IsType<List<DomainModel>>(result);
        }
       
        //[Theory]
        //[InlineData(new DomainModel() {DomainId=1, DomainName="ww", Description="ddd" })]
        //public void To_Check_GetDomainsById_Method(int a)
        //{
        //    //Arrange
        //    var mockRepository = new Mock<DaoRepository<DomainModel>>();
        //    mockRepository.Setup(x => x.Select(new DomainModel())).Returns(new DomainModel());
        //    _domainContext.Setup(x => x.DaoRepository).Returns(mockRepository.Object);

        //    //Act
        //    var bll = new Domain(_domainContext.Object);
        //    var result = bll.GetDomainFromId(new DomainModel());

        //    //Assert
        //    // Assert.IsType<DomainModel>(result);
        //    Assert.True(To_Check_GetDomainsById_Method(a));
        //}
        [Fact]
        public void Check_GetDomainById_Method()
        {
            //Arrange
            var mockRepository = new Mock<DaoRepository<DomainModel>>();
            mockRepository.Setup(x => x.Select(It.IsAny<DomainModel>())).Returns(new DomainModel { DomainId=8});
            _domainContext.Setup(x => x.DaoRepository).Returns(mockRepository.Object);

            //Act
            var bll = new Domain(_domainContext.Object);
            var result = bll.GetDomainFromId(new DomainModel());

            //Assert
            Assert.True(result.DomainId == 8);
        }
    }
}
