using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using train_puzzle.Services;

namespace TrainTests
{
    [TestClass]
    public class RouteDistancesTests
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
        public void Output10()
        {
            var routes = routeSvc.GetRoutesByMaxDistance("C", "C", 30);

            Assert.AreEqual(7, routes.Count(), "Expect 7 routes from city C to city C that travel less than 30");
        }
    }
}
