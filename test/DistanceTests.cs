using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using train_puzzle.Services;

namespace TrainTests
{
    [TestClass]
    public class DistanceTests
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
        public void Output1()
        {
            var distance = routeSvc.GetDistance("A", "B", "C");

            Assert.AreEqual((float)9, distance, "Expect A-B-C distance to be 9");
        }

        [TestMethod]
        public void Output2()
        {
            var distance = routeSvc.GetDistance("A", "D");

            Assert.AreEqual((float)5, distance, "Expect A-D distance to be 5");
        }

        [TestMethod]
        public void Output3()
        {
            var distance = routeSvc.GetDistance("A", "D", "C");

            Assert.AreEqual((float)13, distance, "Expect A-D-C distance to be 13");
        }

        [TestMethod]
        public void Output4()
        {
            var distance = routeSvc.GetDistance("A", "E", "B", "C", "D");

            Assert.AreEqual((float)22, distance, "Expect A-E-B-C-D distance to be 22");
        }

        [TestMethod]
        public void Output5()
        {
            var errorMessage = string.Empty;
            try {
                routeSvc.GetDistance("A", "E", "D");
            } catch (Exception e) {
                errorMessage = e.Message;
            }
            

            Assert.AreEqual("NO SUCH ROUTE", errorMessage, "Expect no route to exist for A-E-D");
        }
    }
}
