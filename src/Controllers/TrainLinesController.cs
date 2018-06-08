using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using train_puzzle.Entities;
using train_puzzle.Services;

namespace train_puzzle.Controllers
{
    [Route("api/[controller]")]
    public class TrainLinesController : Controller
    {
        private readonly ITrainLineService lineSvc;
        public TrainLinesController (ITrainLineService lineSvc) {
            this.lineSvc = lineSvc;
        }

        // GET api/trainlines
        [HttpGet]
        public IEnumerable<TrainLine> Get()
        {
            return lineSvc.GetTrainLines();
        }

        // GET api/trainlines/5
        [HttpGet("{id}")]
        public TrainLine Get(string id)
        {
            return lineSvc.GetTrainLine(id);
        }

        // POST api/trainlines
        [HttpPost]
        public void Post([FromBody]AddTrainLineRequest request)
        {
            var lines = lineSvc.Parse(request.InputString);
            foreach(var line in lines) {
                lineSvc.Add(line);
            }
        }

        // DELETE api/trainlines/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            lineSvc.DeleteTrainLine(id);
        }
    }
}
