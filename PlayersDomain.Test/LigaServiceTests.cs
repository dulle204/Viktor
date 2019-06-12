﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayersDatav1;
using PlayersDatav1.Repositories;
using PlayersDatav1.UnitOfWork;

namespace PlayersDomain.Test
{
    [TestClass]
    public class LigaServiceTests
    {
       

        [TestMethod]
        public void ShouldReturnEmptyListIfNoLIgaFound()
        {
            // Arrange
            var uowMock = new Mock<IUnitOfWork>();
            var ligaRepositoryMock = new Mock<ILigaRepository>();
            ligaRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Liga, bool>>>(), It.IsAny<Func<IQueryable<Liga>, IOrderedQueryable<Liga>>>(), It.IsAny<string>())).Returns((List<Liga>)null);
            uowMock.SetupGet(x => x.LigaRepository).Returns(ligaRepositoryMock.Object);
            ILigaService ligaService = new LigaService(uowMock.Object);

            // Act
            var result = ligaService.GetLiga();

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<LigaDomianModel>));
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ShouldReturnCorrectValue()
        {
            Liga liga1 = new Liga
            {
                ID = 1,
                NazivLige = "liga1",
                DrzavaID = 1,
              

            };
            Liga liga2 = new Liga
            {
                ID = 2,
                NazivLige = "liga2",
                DrzavaID = 2,
        
               
            };

            Drzava drzava1 = new Drzava
            {
                ID = 1,
                NazivDrzave = "drzava1"
            };

            Drzava drzava2 = new Drzava
            {
                ID = 2,
                NazivDrzave = "drzava2" 
                
            };
            List<Liga> lige = new List<Liga> { liga1, liga2 };
            List<Drzava> drzava = new List<Drzava> {drzava1,drzava2 };


            var uowMock = new Mock<IUnitOfWork>();
            var ligaRepositoryMock = new Mock<ILigaRepository>();
            var drzavaRepositoryMock = new Mock<IDrzavaRepository>();
            

            ligaRepositoryMock
                .Setup(x => x.Get(It.IsAny<Expression<Func<Liga, bool>>>(), It.IsAny<Func<IQueryable<Liga>, IOrderedQueryable<Liga>>>(), It.IsAny<string>()))
                .Returns(lige);
            uowMock.SetupGet(x => x.LigaRepository).Returns(ligaRepositoryMock.Object);
            drzavaRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Drzava, bool>>>(), It.IsAny<Func<IQueryable<Drzava>, IOrderedQueryable<Drzava>>>(), It.IsAny<string>()))
               .Returns(drzava);
            uowMock.SetupGet(x => x.DrzavaRepository).Returns(drzavaRepositoryMock.Object);
            drzavaRepositoryMock.Setup(x => x.GetByID(It.IsAny<int>())).Returns(drzava1);
            uowMock.SetupGet(x => x.DrzavaRepository).Returns(drzavaRepositoryMock.Object);


            //var mockobject = drzavaRepositoryMock.Object;

            //Returns your mocked new User() instance

            var mockobject =  drzavaRepositoryMock.Object;
            IDrazavaService drazavaService = new DrzavaService(uowMock.Object);
            ILigaService ligaService = new LigaService(uowMock.Object);
          
      




            // Act
            var result = ligaService.GetLiga();
            var re = drazavaService.GetDrzavaByID(1);
            var newDrzavaObject = mockobject.GetByID(1);


            // Assert


            Assert.AreEqual("liga1", result.First().NazivLige, result.First().DrzavaID.ToString(), newDrzavaObject.ID, "1", newDrzavaObject.NazivDrzave ,"drzava1");
            Assert.AreEqual(2, result.Count);
       
        }
    }
}
