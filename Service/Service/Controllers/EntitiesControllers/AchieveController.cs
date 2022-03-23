using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    [RoutePrefix("api/Achieve")]
    public class AchieveController : ApiController
    {
        private readonly IAchieveService achieveService;

        public AchieveController(IAchieveService achieveService)
        {
            this.achieveService = achieveService;
        }


        // GET: api/Achieve/GetAchieve
        [Route("GetAchieve")]
        [HttpGet]
        public IEnumerable<AchieveWebModel> Get()
        {
            try
            {
                var achieveWebModel =
                    MapperHelperWeb.Mapper.Map<IEnumerable<AchieveModel>, IEnumerable<AchieveWebModel>>(
                        achieveService.Get());
                return achieveWebModel;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // GET: api/Achieve/GetAchieveById
        [Route("GetAchieveById")]
        [HttpGet]
        public AchieveWebModel Get(int id)
        {
            try
            {
                var achieveWebModel = MapperHelperWeb.Mapper.Map<AchieveModel, AchieveWebModel>(achieveService.Get(id));
                return achieveWebModel;
            }
            catch (ArgumentNullException ex)
            {
                return new AchieveWebModel();
            }
        }

        // POST: api/Achieve/AddAchieve
        [Route("AddAchieve")]
        [HttpPost]
        public void Post([FromBody] AchieveWebModel model)
        {
            try
            {
                achieveService.Create(MapperHelperWeb.Mapper.Map<AchieveWebModel, AchieveModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // PUT: api/Achieve/UpdateAchieve
        [Route("UpdateAchieve")]
        [HttpPut]
        public void Put(int id, [FromBody] AchieveWebModel model)
        {
            try
            {
                if (id == model.Id)
                {
                    achieveService.Update(MapperHelperWeb.Mapper.Map<AchieveWebModel, AchieveModel>(model));
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

        // DELETE: api/Achieve/DeleteAchieve
        [Route("DeleteAchieve")]
        [HttpDelete]
        public void Delete(AchieveWebModel model)
        {
            try
            {
                achieveService.Remove(MapperHelperWeb.Mapper.Map<AchieveWebModel, AchieveModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }
    }
}