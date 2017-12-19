using ListView.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListView.ViewModels
{
    public class MyRepository
    {
        public const int CycleLength = 20;
        public List<NhanVien> Items = new List<NhanVien>();
        private static MyRepository instance;
        private MyRepository()
        {
            this.GetNext(0);
        }

        public static MyRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MyRepository();
            }
            return instance;
        }

        public List<NhanVien> GetNext(int lastID)
        {
            List<NhanVien> foo = new List<NhanVien>();
            for (int i = lastID; i < lastID + MyRepository.CycleLength; i++)
            {
                var fooItem = new NhanVien()
                {
                    ID = i,
                    Ten = $"Name {i}",
                    
                };
                Items.Add(fooItem);
                foo.Add(fooItem);
            }
            return foo;
        }
    }
}
