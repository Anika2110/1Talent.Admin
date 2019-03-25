using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using OneRPP.Restful.Contracts.Enum;
using OneRPP.Restful.Contracts.Resource;
using OneRPP.Restful.DAO;
using OneRPP.Restful.DAO.Interface;
using OneRPP.Restful.DAO.Model;

namespace OneAuthorityManagementConsole.Tests.Shared
{
    public class SetupTest
    {
        private readonly Mock<IExecuteData> _executeData;
        private readonly Mock<IFindDaoRepository> _findDaoRepository;
        private readonly Mock<IUowConnectionManager> _uowConnectionManager;
        private readonly Mock<ILogger<DaoContext>> _logger;
        private readonly Mock<IDaoRepositoryInitializer> _daoRepositoryInitializer;

        public SetupTest()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);

            _executeData = mockRepository.Create<IExecuteData>();
            _findDaoRepository = mockRepository.Create<IFindDaoRepository>();
            _uowConnectionManager = mockRepository.Create<IUowConnectionManager>();
            _logger = mockRepository.Create<ILogger<DaoContext>>();
            _daoRepositoryInitializer = mockRepository.Create<IDaoRepositoryInitializer>();
        }

        public ServiceProvider Setup()
        {
            //Arrange
            _executeData.Setup(x => x.ExecuteQuery<FakeDaoModel, FakeDaoModel>(It.IsAny<FakeDaoModel>(),
                    It.IsAny<string>(), It.IsAny<DbEngine>(), It.IsAny<IDbConnection>()))
                .Returns(new FakeDaoModel
                {
                    Id = 1
                });

            _executeData.Setup(x => x.ExecuteQuery<FakeDaoModel, FakeDaoModel>(It.IsAny<FakeDaoModel>(),
                    It.IsAny<string>(), It.IsAny<DbEngine>(), It.IsAny<IDbConnection>(), It.IsAny<IDbTransaction>()))
                .Returns(new FakeDaoModel
                {
                    Id = 1
                });

            _uowConnectionManager.Setup(x => x.DbConnectionModel).Returns(new DbConnectionModel(It.IsAny<IDbConnection>(), It.IsAny<DbEngine>()));

            _findDaoRepository.Setup(x => x.FindRepositories(It.IsAny<DaoContext>()))
                .Returns(new List<DaoRepositoryModel>
                {
                    new DaoRepositoryModel{Name = "FakeDaoModel", Type = typeof(MockDaoContext).GetProperty("FakeDaoModel") }
                });


            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient(x => _executeData.Object);

            serviceCollection.AddTransient(x => _daoRepositoryInitializer.Object);

            serviceCollection.AddTransient(x => _findDaoRepository.Object);

            serviceCollection.AddTransient(x => _uowConnectionManager.Object);

            serviceCollection.AddTransient(x => _logger.Object);

            return serviceCollection.BuildServiceProvider();
        }


        public class MockDaoContext : DaoContext
        {
            public MockDaoContext(IServiceProvider serviceProvider) : base(serviceProvider, "") { }
        }

        public class FakeDaoModel
        {
            public int Id { get; set; }
        }
    }
}
