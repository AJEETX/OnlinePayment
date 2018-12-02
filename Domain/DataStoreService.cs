using stripe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stripe.Domain
{
    public interface IDataStoreService
    {
        void Create(PaymentStatus paymentStatus);
        void Update(string email);
    }
    public class DataStoreService : IDataStoreService
    {
        IRepo _IRepo;
        public DataStoreService(IRepo Repo)
        {
            _IRepo = Repo;
        }

        public void Create(PaymentStatus paymentStatus)
        {
            _IRepo.Create(paymentStatus);
        }

        public void Update(string email)
        {
            _IRepo.Update(email);
        }
    }
}
