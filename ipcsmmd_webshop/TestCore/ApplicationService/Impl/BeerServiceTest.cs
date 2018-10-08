using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ipcsmmd_webshop.Core.ApplicationService;
using ipcsmmd_webshop.Core.ApplicationService.Impl;
using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using Moq;
using Xunit;

namespace TestCore.ApplicationService.Impl
{
    public class BeerServiceTest
    {

        [Fact]
        public void CreateNewBeerWithNullBeerThrowsException()
        {
            var repo = new Mock<IBeerRepository>();
            IBeerService beerService = new BeerService(repo.Object);
            Beer newBeer = null;

            Exception ex = Assert.Throws<InvalidDataException>(() => beerService.AddBeer(newBeer));
            Assert.Equal("Input is null!", ex.Message);
        }

        [Fact]
        public void CreateNewBeerWithIDThrowsException()
        {
            var repo = new Mock<IBeerRepository>();
            IBeerService beerService = new BeerService(repo.Object);
            Beer newBeer = new Beer()
            {
                ID = 1,
                Name = "Best_Beer",
                Brand = "Best_Brand",
                Percentage = 50f,
                Type = BeerType.Dark
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => beerService.AddBeer(newBeer));
            Assert.Equal("Cannot add a Beer with existing id!", ex.Message);
        }

        [Fact]
        public void CreateNewBeerWithoutNameThrowsException()
        {
            var repo = new Mock<IBeerRepository>();
            IBeerService beerService = new BeerService(repo.Object);
            Beer newBeer = new Beer()
            {
                Brand = "Best_Brand",
                Percentage = 50f,
                Type = BeerType.Dark
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => beerService.AddBeer(newBeer));
            Assert.Equal("Cannot add a Beer without name!", ex.Message);
        }

        [Fact]
        public void CreateNewBeerWithoutBrandThrowsException()
        {
            var repo = new Mock<IBeerRepository>();
            IBeerService beerService = new BeerService(repo.Object);
            Beer newBeer = new Beer()
            {
                Name = "Best_Beer",
                Percentage = 50f,
                Type = BeerType.Dark
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => beerService.AddBeer(newBeer));
            Assert.Equal("Cannot add a Beer without brand!", ex.Message);
        }

        [Fact]
        public void CreateNewBeer()
        {
            var repo = new Mock<IBeerRepository>();
            IBeerService beerService = new BeerService(repo.Object);
            Beer newBeer = new Beer()
            {
                Name = "Best_Beer",
                Brand = "Best_Brand",
                Percentage = 50f,
                Type = BeerType.Dark
            };

            Beer returnedBeer = beerService.AddBeer(newBeer);
            Assert.Equal(returnedBeer, newBeer);
        }
    }
}
