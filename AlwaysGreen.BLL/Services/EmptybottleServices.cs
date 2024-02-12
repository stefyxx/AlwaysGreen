using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class EmptybottleServices(IEmptybottleRepository _emptybottleRepository)
    {
        //register == Add new
        public List<Emptybottle> GetAll() { return _emptybottleRepository.GetAll(); }

        public Emptybottle? Find(params object[] id) 
        {
            Emptybottle? emptybottle = _emptybottleRepository.Find(id); 
            if (emptybottle is null)
            {
                throw new KeyNotFoundException();
            }else return emptybottle;

        }
        public Emptybottle Add(Emptybottle e) 
        {
            Emptybottle? eBIsexisted = _emptybottleRepository.FindIsExisting(e);
            if (eBIsexisted == null) return _emptybottleRepository.Add(e);
            else return eBIsexisted; //in questo caso e ==== eBIsexisted
        }

        public void Update(Emptybottle e) 
        {
            Emptybottle? emptybottle = _emptybottleRepository.Find(e.Id);
            //controllo già fatto in Find
            //if (emptybottle is null)
            //{
            //    throw new KeyNotFoundException();
            //}
            //else
            _emptybottleRepository.Update(e);
        }
        
        public Emptybottle MyUpdate(Emptybottle e)
        {
            try
            {
                using TransactionScope transaction = new TransactionScope();
                Emptybottle? emptybottle = _emptybottleRepository.Find(e.Id);
                if (emptybottle is null)
                {
                    throw new KeyNotFoundException();
                }
                else _emptybottleRepository.Update(e);

                transaction.Complete();
                return e;
            }
            catch (Exception) { throw new Exception("It was not possible to update"); }

        }

        public void Delete(Emptybottle e) { _emptybottleRepository.Delete(e); }
    }
}
