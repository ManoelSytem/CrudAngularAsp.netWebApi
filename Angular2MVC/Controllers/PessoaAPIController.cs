using Angular2MVC.DBContext;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Angular2MVC.Controllers
{
    public class PessoaAPIController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            return ToJson(GpDB.tb_usuario.AsEnumerable());
        }

       public HttpResponseMessage Post([FromBody]tb_usuario value)
        {
            GpDB.tb_usuario.Add(value);             
            return ToJson(GpDB.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]tb_usuario value)
        {
            GpDB.Entry(value).State = EntityState.Modified;
            return ToJson(GpDB.SaveChanges());
        }
        public HttpResponseMessage Delete(int id)
        {
            GpDB.tb_usuario.Remove(GpDB.tb_usuario.FirstOrDefault(x => x.Id == id));
            return ToJson(GpDB.SaveChanges());
        }
    }
}
