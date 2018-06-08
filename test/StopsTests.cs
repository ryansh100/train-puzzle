using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using train_puzzle.Services;

namespace TrainTests
{
    [TestClass]
    public class StopsTests
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
        public void Output6()
        {
            var routes = routeSvc.GetRoutesByStops("C", "C", 3);

            Assert.AreEqual(2, routes.Count(), "Expect Number of routes from C to C with 3 or less stops to be 2");
        }

        [TestMethod]
        public void Output7()
        {
            var routes = routeSvc.GetRoutesByStops("A", "C", 4, 4);

            Assert.AreEqual(3, routes.Count(), "Expect 3 routes from A to C that make exactly 4 stops.");
        }
    }
}
