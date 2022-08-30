using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Test.Stubs;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using Moq;

namespace GeoObservables.Api.Aplication.Test.MockRepository
{
    public class RolesRepositoryMock
    {
        public Mock<IRolesRepository> _rolesRepository { get; set; }
        public RolesRepositoryMock()
        {
            _rolesRepository = new Mock<IRolesRepository>();
        }

        [SetUp]
        public void Setup()
        {
            _rolesRepository.Setup((x) => x.Add(It.IsAny<RolesEntity>())).ReturnsAsync(RolesStub.roles_1);
            _rolesRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(3)))).Returns((Task<RolesEntity>)Task.Delay(3));
            _rolesRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => !p.Equals(3)))).Returns((Task<RolesEntity>)Task.Delay(10));
            _rolesRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _rolesRepository.Setup((x) => x.Get(It.IsAny<int>())).ReturnsAsync(RolesStub.roles_1);
            _rolesRepository.Setup((x) => x.GetAll()).Returns((Task<IEnumerable<RolesEntity>>)RolesStub.rolesList);
            
        }
    }
}
