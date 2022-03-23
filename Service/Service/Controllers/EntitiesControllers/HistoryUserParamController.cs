using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    [RoutePrefix("api/HistoryUserParam")]
    public class HistoryUserParamController : ApiController
    {
        private readonly IHistoryUserParamService historyUserParamService;

        public HistoryUserParamController(IHistoryUserParamService historyUserParamService)
        {
            this.historyUserParamService = historyUserParamService;
        }

        // GET: api/HistoryUserParam/GetHistoryUserParam
        [Route("GetHistoryUserParam")]
        [HttpGet]
        public IEnumerable<HistoryUserParamWebModel> Get()
        {
            try
            {
                var historyUserParamModel =
                    MapperHelperWeb.Mapper
                        .Map<IEnumerable<HistoryUserParamModel>, IEnumerable<HistoryUserParamWebModel>>(
                            historyUserParamService.Get());
                return historyUserParamModel;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // GET: api/HistoryUserParam/GetHistoryUserParamById
        [Route("GetHistoryUserParamById")]
        [HttpGet]
        public HistoryUserParamWebModel Get(int id)
        {
            try
            {
                var historyUserParamModel =
                    MapperHelperWeb.Mapper.Map<HistoryUserParamModel, HistoryUserParamWebModel>(
                        historyUserParamService.Get(id));
                return historyUserParamModel;
            }
            catch (ArgumentNullException ex)
            {
                return new HistoryUserParamWebModel();
            }
        }

        // POST: api/HistoryUserParam/AddHistoryUserParam
        [Route("AddHistoryUserParam")]
        [HttpPost]
        public void Post([FromBody] HistoryUserParamWebModel model)
        {
            try
            {
                historyUserParamService.Create(MapperHelperWeb.Mapper
                    .Map<HistoryUserParamWebModel, HistoryUserParamModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // PUT: api/HistoryUserParam/UpdateHistoryUserParamById
        [Route("UpdateHistoryUserParamById")]
        [HttpPut]
        public void Put(int id, [FromBody] HistoryUserParamWebModel model)
        {
            try
            {
                if (id == model.Id)
                {
                    historyUserParamService.Update(
                        MapperHelperWeb.Mapper.Map<HistoryUserParamWebModel, HistoryUserParamModel>(model));
                }
                else
                {
                    throw new Exception("uncorrect id");
                }
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // DELETE: api/HistoryUserParam/DeleteHistoryUserParam
        [Route("DeleteHistoryUserParam")]
        [HttpDelete]
        public void Delete(HistoryUserParamWebModel model)
        {
            try
            {
                historyUserParamService.Remove(MapperHelperWeb.Mapper
                    .Map<HistoryUserParamWebModel, HistoryUserParamModel>(model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}