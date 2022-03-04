using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchasation> Purchasations { get; }

        void SavePurchasation(Purchasation purchasation);
    }
}
