using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stripe.Domain
{
    public interface IDataStoreService
    {
        void Update(string email);
    }
    public class DataStoreService : IDataStoreService
    {
        public void Update(string email)
        {
            // update DB
        }
    }
}
