using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventOfCode2017.Controllers
{
    #region Usings
    using API.ResponseModels;
    using LibAdventOfCode2017.Products;
    using Unity;
    using Unity.Resolution;
    #endregion

    public class AdventOfCode2017Controller : ApiController
    {
        [HttpPost]
        [Route("api/AdventOfCode2017/Day9/Process")]
        public int GetGroupScore([NakedBody] string input)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<Day9Product>();
            Day9Product day9 = container.Resolve<Day9Product>(new ParameterOverride("input", input));

            try
            {
                return (int)day9.Process();
            }
            catch (Exception ex)
            {
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                httpResponseMessage.Content = new StringContent(ex.Message);
                throw new HttpResponseException(httpResponseMessage);
            }
        }
    }
}
