using _1Talent.Admin.DAL.Context;
using _1Talent.Admin.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using OneRPP.Restful.Contracts.Enum;
using OneRPP.Restful.Contracts.Resource;
using OneRPP.Restful.DAO;
using OneRPP.Restful.DAO.Interface;
using OneRPP.Restful.DAO.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _1Talent.Admin.Tests.DAL
{
    public class DomainRepositoryTest
    {
        private readonly Mock<IExecuteData> _executeData;
        private readonly Mock<IFindDaoRepository> _findDaoRepository;
        private readonly Mock<IUowConnectionManager> _uowConnectionManager;
        private readonly Mock<ILogger<DaoContext>> _logger;

        public DomainRepositoryTest()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            _executeData = mockRepository.Create<IExecuteData>();
            _findDaoRepository = mockRepository.Create<IFindDaoRepository>();
            _uowConnectionManager = mockRepository.Create<IUowConnectionManager>();
            _logger = mockRepository.Create<ILogger<DaoContext>>();
            mockRepository.Create<IDaoRepositoryInitializer>();
        }
        public ServiceProvider SetUp()
        {
            _executeData.Setup(x => x.ExecuteQuery<DomainModel, List<DomainModel>>(It.IsAny<DomainModel>(),
                    It.IsAny<string>(), It.IsAny<DbEngine>(), It.IsAny<System.Data.IDbConnection>()))
                .Returns(new List<DomainModel>());

            _uowConnectionManager.Setup(x => x.DbConnectionModel).Returns(new DbConnectionModel(It.IsAny<System.Data.IDbConnection>(), It.IsAny<DbEngine>()));

            _findDaoRepository.Setup(x => x.FindRepositories(It.IsAny<DaoContext>()))
                .Returns(new List<DaoRepositoryModel>
                {
                    new DaoRepositoryModel{Name = "DomainRepository", Type = typeof(DomainContext).GetProperty("DomainRepository") }
                });

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient(x => _executeData.Object);
            serviceCollection.AddTransient(x => _findDaoRepository.Object);
            serviceCollection.AddTransient<IDaoRepositoryInitializer>(x => new DaoRepositoryInitializer(_findDaoRepository.Object));
            serviceCollection.AddTransient(x => _uowConnectionManager.Object);
            serviceCollection.AddTransient(x => _logger.Object);
            return serviceCollection.BuildServiceProvider();
        }
        private DomainModel GetDomain()
        {
            return new DomainModel()
            {
                DomainName = "",
                Description=""
            };
        }
    }
}
