using API_WebSach.EntityView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSach.Services
{
    public interface  ISachRepository
    {
        List<SachView> GetAllProduct(string search,string price_desc,int page);
    }
}
