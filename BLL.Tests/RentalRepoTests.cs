using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using DAL.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Saab.Api.Controllers;
using Xunit;

namespace BLL.Tests
{
    public class RentalRepoTests
    {
        [Fact]
        public void RegisterRentalTest()
        {
            Fixture fixture = new Fixture();
            var payload = fixture.Build<Payload>().Create();


            //Setup
            var mockRepo = new Mock<IRentalRepository>();

            mockRepo.Setup(rep => rep.Return(payload));
            var controller = new RentalController(mockRepo.Object);


            //Act
            var okRes = controller.Post(payload);

            // Assert
            Assert.Equal("Done", okRes.Value);
        }
    }
}
