using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;
        
        public EFPurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }
        
        public IQueryable<Purchasation> Purchasations => context.Purchasations.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchasation(Purchasation purchasation)
        {
            context.AttachRange(purchasation.Lines.Select(x => x.Book));

            if(purchasation.PurchasationId == 0)
            {
                context.Purchasations.Add(purchasation);
            }

            context.SaveChanges();
        }
    }
}
