using Moq;
using web_app_domain;
using web_app_repository;

namespace Test
{
    public class UsuarioRepositoryTest
    {
        [Fact]
        public async Task ListarUsuarios()
        {
            //Arrange
            var usuarios = new List<Usuario>() {
                new Usuario()
                {
                    Email = "xxx@gmail.com",
                    Id = 1,
                    Nome = "Thiago xavier"
                },
                 new Usuario()
                {
                    Email = "usuari2@gmail.com",
                    Id = 2,
                    Nome = "Ana"
                }
            };
            var userRepositoryMock = new Mock<IUsuarioRepository>();
            userRepositoryMock.Setup(u => u.ListarUsuarios()).ReturnsAsync(usuarios);
            var userRepository = userRepositoryMock.Object;

            //Act 
            var result = await userRepository.ListarUsuarios();

            //Assert
            Assert.Equal(usuarios, result);
        }


        [Fact]
        public async Task SalvarUsuario()
        {
            //arrange
            var usuario = new Usuario()
            {
                Id = 1,
                Email = "thiago@fiap.com",
                Nome = "Thiago Xavier"
            };
            var userRepositoryMock = new Mock<IUsuarioRepository>();
            userRepositoryMock
                .Setup(u => u.SalvarUsuario(It.IsAny<Usuario>()))
                .Returns(Task.CompletedTask);
            var userRepository = userRepositoryMock.Object;

            //act
            await userRepository.SalvarUsuario(usuario);

            //assert
            userRepositoryMock
          .Verify(u => u.SalvarUsuario(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
