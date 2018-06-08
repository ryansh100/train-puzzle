using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using train_puzzle.Services;

namespace TrainTests
{
    [TestClass]
    public class ShortestRoutesTests
    {
        TrainLineService lineSvc;
        RouteService routeSvc;
        
        [TestInitialize]
        public void Init() {
            lineSvc = new TrainLineService();
            routeSvc = new RouteService(lineSvc);

            var lines = lineSvc.Parse("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            foreach(var line in lines) {
                lineSvc.Add(line);
            }
        }

        [TestMethod]
        public void Output8()
        {
            var shortest = routeSvc.GetShortestRoute("A", "C");

            Assert.AreEqual((float)9, shortest.Distance, "Expect shortest route from A to C to be 9");
        }

        [TestMethod]
        public void Output9()
        {
            var shortest = routeSvc.GetShortestRoute("B", "B");

            Assert.AreEqual((float)9, shortest.Distance, "Expect shortest route from B to B to be 9");
        }
    }
}
