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
                NazivLige = "Liga1",
                DrzavaID = 1,
                
               

            };
            Liga liga2 = new Liga
            {
                ID = 2,
                NazivLige = "Liga2",
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
            List<Drzava> drzavas = new List<Drzava> {drzava1,drzava2 };
            var uowMock = new Mock<IUnitOfWork>();
            var ligaRepositoryMock = new Mock<ILigaRepository>();
            ligaRepositoryMock
                .Setup(x => x.Get(It.IsAny<Expression<Func<Liga, bool>>>(), It.IsAny<Func<IQueryable<Liga>, IOrderedQueryable<Liga>>>(), It.IsAny<string>()))
                .Returns(lige);
            uowMock.SetupGet(x => x.LigaRepository).Returns(ligaRepositoryMock.Object);
            ILigaService ligaService = new LigaService(uowMock.Object);

            var drzavaRepositoryMock=new Mock<IDrzavaRepository>();

            drzavaRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Drzava, bool>>>(), It.IsAny<Func<IQueryable<Drzava>, IOrderedQueryable<Drzava>>>(), It.IsAny<string>()))
                .Returns(drzavas);
            uowMock.SetupGet(x => x.DrzavaRepository).Returns(drzavaRepositoryMock.Object);


            IDrazavaService drazavaService = new DrzavaService(uowMock.Object);

            // Act
            var result = ligaService.GetLiga();
            var re = drazavaService.GetDrzavaByID(1);

            // Assert

           
            Assert.AreEqual(2, result.Count);
          //  Assert.AreEqual(2, re.Count);
           // Assert.IsInstanceOfType(result, typeof(List<DrzavaDomenModel>));
           Assert.AreEqual("liga1",result.First().NazivLige);
        }
    }
}