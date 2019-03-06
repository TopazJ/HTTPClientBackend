using System.Collections.Generic;
using HTTPClientWebApp.Models;
using HTTPClientWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTTPClientWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataModelResultController : ControllerBase
    {
        private readonly DataModelResultService _DataModelResultService;

        public DataModelResultController(DataModelResultService DataModelResultService)
        {
            _DataModelResultService = DataModelResultService;
        }

        [HttpGet]
        public ActionResult<List<DataModelResult>> Get()
        {
            return _DataModelResultService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetDataModelResult")]
        public ActionResult<DataModelResult> Get(string id)
        {
            var DataModelResult = _DataModelResultService.Get(id);

            if (DataModelResult == null)
            {
                return NotFound();
            }

            return DataModelResult;
        }

        [HttpPost]
        public ActionResult<DataModelResult> Create(DataModelResult DataModelResult)
        {
            _DataModelResultService.Create(DataModelResult);

            return CreatedAtRoute("GetDataModelResult", new { id = DataModelResult.Id.ToString() }, DataModelResult);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, DataModelResult DataModelResultIn)
        {
            var DataModelResult = _DataModelResultService.Get(id);

            if (DataModelResult == null)
            {
                return NotFound();
            }

            _DataModelResultService.Update(id, DataModelResultIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var DataModelResult = _DataModelResultService.Get(id);

            if (DataModelResult == null)
            {
                return NotFound();
            }

            _DataModelResultService.Remove(DataModelResult.Id);

            return NoContent();
        }
    }
}