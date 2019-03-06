using System.Collections.Generic;
using HTTPClientWebApp.Models;
using HTTPClientWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTTPClientWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataModelController : ControllerBase
    {
        private readonly DataModelService _DataModelService;
        private readonly DataModelResultService _DataModelResultService;

        public DataModelController(DataModelService DataModelService, DataModelResultService DMRS)
        {
            _DataModelService = DataModelService;
            _DataModelResultService = DMRS;
        }

        [HttpGet]
        public ActionResult<List<DataModel>> Get()
        {
            return _DataModelService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetDataModel")]
        public ActionResult<DataModel> Get(string id)
        {
            var DataModel = _DataModelService.Get(id);

            if (DataModel == null)
            {
                return NotFound();
            }

            return DataModel;
        }

        [HttpPost]
        public ActionResult<DataModelResult> Create(DataModel DataModel)
        {

            _DataModelService.Create(DataModel);
            DataModelResult DMR = new DataModelResult(DataModel);
            _DataModelResultService.Create(DMR);

            return CreatedAtRoute("GetDataModelResult", new { id = DMR.Id.ToString() }, DMR);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, DataModel DataModelIn)
        {
            var DataModel = _DataModelService.Get(id);

            if (DataModel == null)
            {
                return NotFound();
            }

            _DataModelService.Update(id, DataModelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var DataModel = _DataModelService.Get(id);

            if (DataModel == null)
            {
                return NotFound();
            }

            _DataModelService.Remove(DataModel.Id);

            return NoContent();
        }
    }
}