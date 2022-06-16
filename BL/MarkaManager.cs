using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MarkaManager
    {
        DatabaseContext context = new DatabaseContext();
        public List<Marka> GetAll()
        {
            return context.Markalar.ToList();
        }
    }
}
