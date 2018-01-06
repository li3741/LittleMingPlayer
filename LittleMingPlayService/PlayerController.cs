using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LittleMingPlayService
{
    public class PlayerController : ApiController
    {
        /// <summary>
        /// api/player/0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string Play(int id)
        {
            PlayerHelper.Inst().Play(id);
            return PlayerHelper.Inst().GetPlayingFile();
        }

    }
}
