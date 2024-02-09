using AlwaysGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlwaysGreen.BLL.Interfaces
{
    public interface IParticularRepository
    {
        public List<Particular> GetAll();

        public Particular Add(Particular p);

        public Particular? Find(params object[] id);

        public void Update(Particular p);
        public Particular? myUpdate(Particular p, string username, string email, Address address, string phoneNumber, byte[] psw);
    }
}
