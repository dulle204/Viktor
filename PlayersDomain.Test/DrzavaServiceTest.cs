using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayersDatav1;
using PlayersDatav1.Repositories;
using PlayersDatav1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain.Test
{
    [TestClass]
    public class DrzavaServiceTest
    {

        [TestMethod]
        public void ShouldReturnCorrectValue1()
        {


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

            List<Drzava> drzavas = new List<Drzava> { drzava1, drzava2 };
            var uowMock = new Mock<IUnitOfWork>();

            ILigaService ligaService = new LigaService(uowMock.Object);

            var drzavaRepositoryMock = new Mock<IDrzavaRepository>();

            drzavaRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Drzava, bool>>>(), It.IsAny<Func<IQueryable<Drzava>, IOrderedQueryable<Drzava>>>(), It.IsAny<string>()))
                .Returns(drzavas);
            uowMock.SetupGet(x => x.DrzavaRepository).Returns(drzavaRepositoryMock.Object);


            IDrazavaService drazavaService = new DrzavaService(uowMock.Object);

            // Act
           
            var re = drazavaService.GetDrzavas();

            // Assert

            Assert.AreEqual("drzava1", re.First().NazivDrzave);
            Assert.AreEqual(2, re.Count);
       
        }
    }
}