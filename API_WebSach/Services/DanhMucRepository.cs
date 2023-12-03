using API_WebSach.EntityView;
using API_WebSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSach.Services
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly NxbKimDongContext _db;
        public DanhMucRepository(NxbKimDongContext db)
        {
            _db = db;
        }
        public DanhMucView Add(DanhMucModel dm)
        {
            var createDM = new DanhMucSp
            {
                Name = dm.Name
            }; // tao object 
            _db.DanhMucSps.Add(createDM);
            _db.SaveChanges();
            return new DanhMucView
            {
                MaDM = createDM.Id,
                Name = createDM.Name,
        };


        }

        public void Delete(int id)
        {
            var dmDelete = _db.DanhMucSps.Find(id);
            if(dmDelete != null)
            {
                _db.DanhMucSps.Remove(dmDelete);
            }
        }

        public List<DanhMucView> GetAllDM()
        {
            var listDM = _db.DanhMucSps.Select(dm => new DanhMucView
            {
                MaDM = dm.Id,
                Name = dm.Name
            }
            );
            return listDM.ToList();
        }

        public DanhMucView GetByID(int id)
        {
            var dmById = _db.DanhMucSps.Find(id);
            if(dmById != null)
            {// da ton tai

                return new DanhMucView
                {
                    MaDM = dmById.Id,
                    Name = dmById.Name, 
                };
            }
            return null;
        }

        public void Update(DanhMucView dm)
        {
            var dmUpdate = _db.DanhMucSps.Find(dm.MaDM);
            if(dmUpdate != null)
            {
                dmUpdate.Name = dm.Name;
                _db.SaveChanges();
            }
        }
    }
}
