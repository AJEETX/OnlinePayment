using stripe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stripe.Domain
{
    public interface IRepo
    {
        void Update(string email);
    }
    public class Repo : IRepo
    {
        ApplicationContext _ctx;
        public Repo(ApplicationContext ctx)
        {
            _ctx = ctx;
        }
        public void Update(string email)
        {
            var status = _ctx.Set<PaymentStatus>().Where(p=> p.Email == email).FirstOrDefault();
            status.IsComplete = true; status.Time = DateTime.Now;
            _ctx.Set<PaymentStatus>().Update(status);
            _ctx.SaveChanges();
        }
    }
}
