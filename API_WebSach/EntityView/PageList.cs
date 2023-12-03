using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSach.EntityView
{
    public class PageList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int totalPage { get; set; }
        public PageList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            totalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);

        }
        public static PageList<T> Create(IQueryable<T> sources, int pageIndex, int pageSize)
        {
            var count = sources.Count();
            var items = sources.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<T>(items, count, pageIndex, pageSize);
        }

            
    }
    //{
    //    public int PageIndex { get; set; }
    //    public int totalPage { get; set; }
    //    public PageList(List<T> items, int count , int pageIndex, int pageSize)
    //    {
    //        PageIndex = pageIndex; // trang hiện tại
    //        totalPage = (int)Math.Ceiling(count / (double)pageSize);// tổng số trang đc làm tròn lên
    //        AddRange(items); // thêm các phần tử vào PageList

    //    }
    //    public static PageList<T> Create (IQueryable<T> source, int pageIndex, int pageSize)
    //    {
    //        var count = source.Count();
    //        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
    //        return new PageList<T>(items, count, pageIndex, pageSize);
    //    }

    }

