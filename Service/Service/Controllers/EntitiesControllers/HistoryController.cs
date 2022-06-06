using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    [RoutePrefix("api/History")]
    public class HistoryController : ApiController
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        // GET: api/History
        [Route("GetHistory")]
        [HttpGet]
        public AvgHistoryWebModel Get()
        {
            try
            {
                var dataStepsWebModel =
                    MapperHelperWeb.Mapper.Map<AvgHistoryDataModel, AvgHistoryWebModel>(
                        _historyService.GetAllAvgDataSteps());
                return dataStepsWebModel;
            }
            catch (ArgumentNullException ex)
            {
                return new AvgHistoryWebModel();
            }
            catch (Exception ex)
            {
                return new AvgHistoryWebModel();
            }
        }

        // GET: api/History/5
        [Route("GetHistoryById")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/History
        [Route("AddHistory")]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/History/5
        [Route("UpdateHistoryById")]
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/History/5
        [Route("DeleteHistoryById")]
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
