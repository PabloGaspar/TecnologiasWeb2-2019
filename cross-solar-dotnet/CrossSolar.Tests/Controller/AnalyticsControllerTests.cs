using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Domain;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTests
    {
        public AnalyticsControllerTests()
        {
            _analyticsController = new AnalyticsController(_analyticsRepositoryMock.Object, _panelRepositoryMock.Object);
           
        }

        private readonly AnalyticsController _analyticsController;

        private  Mock<IAnalyticsRepository> _analyticsRepositoryMock = new Mock<IAnalyticsRepository>();
        private  Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();

        string panelId = "AAAA1111BBBB2222";

        IQueryable<Panel> panels = new MyAsyncEnumerable<Panel>(new List<Panel>
            {
                new Panel
                {
                    Id = 1,
                    Brand = "Areva",
                    Latitude = 12.345678,
                    Longitude = 98.7655432,
                    Serial = "AAAA1111BBBB2222"
                }
            });

        IQueryable<OneHourElectricity> oneHourElectricitys = new MyAsyncEnumerable<OneHourElectricity>(new List<OneHourElectricity>
            {
                new OneHourElectricity
                {
                    Id = 1,
                    PanelId = "AAAA1111BBBB2222",
                    KiloWatt = 1200,
                    DateTime = DateTime.Parse("07/07/2018")
                },
                new OneHourElectricity
                {
                    Id = 1,
                    PanelId = "AAAA1111BBBB2222",
                    KiloWatt = 300,
                    DateTime = DateTime.Parse("07/07/2018")
                },
                new OneHourElectricity
                {
                    Id = 1,
                    PanelId = "AAAA1111BBBB2222",
                    KiloWatt = 600,
                    DateTime = DateTime.Parse("08/07/2018")
                }
            });

        [Fact]
        public async Task Get_ShouldGetOneHourElectricityListModel()
        {
            // Arrange
           
            _panelRepositoryMock.Setup(mock => mock.Query()).Returns(panels);

            _analyticsRepositoryMock.Setup(mock => mock.Query())
                .Returns(oneHourElectricitys);

            // Act
            var result = await _analyticsController.Get(panelId);

            // Assert
            Assert.NotNull(result);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldPostOneHourElectricityModel()
        {
            // Arrange
            var oneHourElectricity = new OneHourElectricityModel
            {
                KiloWatt = 1200,
                DateTime = new System.DateTime()
            };

            // Act
            var result = await _analyticsController.Post(panelId, oneHourElectricity);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task Get_ShouldGetDayResult()
        {
            // Arrange
            _panelRepositoryMock.Setup(mock => mock.Query()).Returns(panels);
            _analyticsRepositoryMock.Setup(mock => mock.Query())
                .Returns(oneHourElectricitys);

            // Act
            var result = await _analyticsController.DayResults(panelId);

            // Assert
            Assert.NotNull(result);

            var dayResult = result as OkObjectResult;
            Assert.NotNull(dayResult);
            Assert.Equal(200, dayResult.StatusCode);
        }
    }
}
