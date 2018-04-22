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

        public void Update(string email)
        {
            throw new NotImplementedException();
        }
    }
}
