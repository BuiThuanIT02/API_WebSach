using API_WebSach.EntityView;
using API_WebSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSach.Services
{
    public class SachRepository : ISachRepository
    {
        private readonly NxbKimDongContext _db;
        public SachRepository(NxbKimDongContext db)
        {
            _db = db;
        }
        public List<SachView> GetAllProduct(string search, string price_desc,int page)
        {  // price_desc : có thể nhận giá trị null
            var products = _db.Saches.AsQueryable();// không thực hiện truy vấn ngay lập tức, các phương thức LINQ sẽ đc thực hiện sau này
            if (!string.IsNullOrEmpty(search))
            {

                switch (price_desc)
                {
                    case "price_asec":
                        products = products.OrderBy(hh => hh.Price);
                        break;
                    case "price_desc":
                        products = products.OrderByDescending(hh => hh.Price);
                        break;
                    default: products = products.Where(hh => hh.Name.Contains(search)); break;

                }

            }
            products = products.Skip((page - 1) * 5).Take(5);


            var resulft = products.Select(hh => new SachView
            {// ép kiểu về 
                Id = hh.Id,
                Name = hh.Name,
                Image = hh.Image,
                Price = hh.Price,
                Quantity = hh.Quantity,
                Sale = hh.Sale

            });
            return resulft.ToList();
        }
    }
}
