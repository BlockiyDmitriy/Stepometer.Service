using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    [RoutePrefix("api/Friends")]
    public class FriendsController : ApiController
    {
        private readonly IFriendsService friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            this.friendsService = friendsService;
        }


        // GET: api/Friends/GetFriends
        [Route("GetFriends")]
        [HttpGet]
        public IEnumerable<FriendsWebModel> Get()
        {
            try
            {
                var friendsWebModel =
                    MapperHelperWeb.Mapper.Map<IEnumerable<FriendsModel>, IEnumerable<FriendsWebModel>>(
                        friendsService.Get());
                return friendsWebModel;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // GET: api/Friends/GetFriendsById
        [Route("GetFriendsById")]
        [HttpGet]
        public FriendsWebModel Get(int id)
        {
            try
            {
                var friendsWebModel = MapperHelperWeb.Mapper.Map<FriendsModel, FriendsWebModel>(friendsService.Get(id));
                return friendsWebModel;
            }
            catch (ArgumentNullException)
            {
                return new FriendsWebModel();
            }
        }

        // POST: api/Friends/AddFriends
        [Route("AddFriends")]
        [HttpPost]
        public void Post([FromBody] FriendsWebModel model)
        {
            try
            {
                friendsService.Create(MapperHelperWeb.Mapper.Map<FriendsWebModel, FriendsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // PUT: api/Friends/UpdateFriendsById
        [Route("UpdateFriendsById")]
        [HttpPut]
        public void Put(int id, [FromBody] FriendsWebModel model)
        {
            try
            {
                if (id == model.Acc1.Id || id == model.Acc2.Id)
                {
                    friendsService.Update(MapperHelperWeb.Mapper.Map<FriendsWebModel, FriendsModel>(model));
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

        // DELETE: api/Friends/DeleteFriends
        [Route("DeleteFriends")]
        [HttpDelete]
        public void Delete(FriendsWebModel model)
        {
            try
            {
                friendsService.Remove(MapperHelperWeb.Mapper.Map<FriendsWebModel, FriendsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }
    }
}