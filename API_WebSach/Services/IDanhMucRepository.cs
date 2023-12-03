using API_WebSach.EntityView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSach.Services
{
    public interface IDanhMucRepository
    {
        List<DanhMucView> GetAllDM();
        DanhMucView Add(DanhMucModel dm);
        DanhMucView GetByID(int id);
        void Update(DanhMucView dm);
        void Delete(int id);
    }
}
