using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using train_puzzle.Entities;

namespace train_puzzle.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly IRouteService routeSvc;

        public ReportsController(IRouteService routeSvc) {
            this.routeSvc = routeSvc;
        }

        // GET api/reports
        [HttpGet]
        public RouteReport Get()
        {
            var report = new RouteReport();
            // Test 1
            try {
                var distance = routeSvc.GetDistance("A", "B", "C");
                report.Output1 = distance.ToString();
            } catch (Exception e) {
                report.Output1 = e.Message;
            }
            
            // Test 2
            try {
                var distance = routeSvc.GetDistance("A", "D");
                report.Output2 = distance.ToString();
            } catch (Exception e) {
                report.Output2 = e.Message;
            }

            // Test 3
            try {
                var distance = routeSvc.GetDistance("A", "D", "C");
                report.Output3 = distance.ToString();
            } catch (Exception e) {
                report.Output3 = e.Message;
            }

            // Test 4
            try {
                var distance = routeSvc.GetDistance("A", "E", "B", "C", "D");
                report.Output4 = distance.ToString();
            } catch (Exception e) {
                report.Output4 = e.Message;
            }

            // Test 5
            try {
                var distance = routeSvc.GetDistance("A", "E", "D");
                report.Output5 = distance.ToString();
            } catch (Exception e) {
                report.Output5 = e.Message;
            }
            
            // Test 6
            var ccRoutesMax3 = routeSvc.GetRoutesByStops("C", "C", 3);
            report.Output6 = ccRoutesMax3.Count();

            // Test 7
            var acRoutesExact4 = routeSvc.GetRoutesByStops("A", "C", 4, 4);
            report.Output7 = acRoutesExact4.Count();

            // Test 8
            var acShortest = routeSvc.GetShortestRoute("A", "C");
            report.Output8 = acShortest == null ? 0 : acShortest.Distance;

            // Test 9
            var bbShortest = routeSvc.GetShortestRoute("B", "B");
            report.Output9 = bbShortest == null ? 0 : bbShortest.Distance;

            // Test 10
            var ccRoutesMax30Distance = routeSvc.GetRoutesByMaxDistance("C", "C", 30);
            report.Output10 = ccRoutesMax30Distance.Count();

            return report;
        }
    }
}
