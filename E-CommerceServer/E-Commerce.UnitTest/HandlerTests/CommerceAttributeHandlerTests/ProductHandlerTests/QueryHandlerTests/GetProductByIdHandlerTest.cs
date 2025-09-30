using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetProductById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.ProductHandlerTests.QueryHandlerTests
{
    public class GetProductByIdHandlerTest
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly GetProductByIdQueryHandler _handler;

        public GetProductByIdHandlerTest()
        {
            _productServiceMock = new Mock<IProductService>();
            _handler = new GetProductByIdQueryHandler(_productServiceMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Call_GetByIdAsync_And_Return_Product()
        {
            // Arrange
            var productId = 1;
            var query = new GetProductByIdQuery(productId);

            var expectedProduct = new Product
            {
                Id = productId,
                Name = "Test Product",
                Description = "Sample description",
                ImageUrl = "http://example.com/image.jpg",
                Price = 199.99m,
                Status = ProductStatus.Active,
                StockQuantity = 20,
                CategoryId = 5
            };

            _productServiceMock
                .Setup(service => service.GetByIdAsync(query, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProduct);

            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedProduct.Id, result.Id);
            Assert.Equal(expectedProduct.Name, result.Name);
            Assert.Equal(expectedProduct.Description, result.Description);

            _productServiceMock.Verify(service =>
                service.GetByIdAsync(query, cancellationToken), Times.Once);
        }
    }
}
