
using Moq;
using Microsoft.AspNetCore.Mvc;
using u23668475_HW01.Controllers;
using u23668475_HW01.Models;
using u23668475_HW01.Repositories;

namespace u23668475_HW01_Tests.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            var mockRepo = new Mock<IproductRepository>();
            mockRepo.Setup(repo => repo.getProductsById(1)).ReturnsAsync((Product)null);

            var controller = new productController(mockRepo.Object);
            var result = await controller.getProduct(1);

            Assert.IsType<NotFoundResult>(result.Result);  
        }

    }
}
