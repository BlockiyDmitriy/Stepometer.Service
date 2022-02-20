using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    public class HistoryUserParamController : ApiController
    {
        private readonly IHistoryUserParamService historyUserParamService;

        public HistoryUserParamController(IHistoryUserParamService historyUserParamService)
        {
            this.historyUserParamService = historyUserParamService;
        }

        // GET: api/HistoryUserParam
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

        // GET: api/HistoryUserParam/5
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

        // POST: api/HistoryUserParam
        // new
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

        // PUT: api/HistoryUserParam/5
        // modify
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

        // DELETE: api/HistoryUserParam/5
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