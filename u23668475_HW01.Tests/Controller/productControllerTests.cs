using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using u23668475_HW01.Controllers;
using u23668475_HW01.Models;

namespace u23668475_HW01.Tests
{
    internal class productControllerTests
    {
        [Fact]

        public async Task getProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            var mockRepo = new Mock<IproductRepository>
        }

    }
}
