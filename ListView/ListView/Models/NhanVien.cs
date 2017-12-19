using System;
using System.Collections.Generic;
using System.Text;

namespace ListView.Models
{
    public class NhanVien
    {

        // chú ý 0 tạo hàm khởi tạo kiểu này=>Lỗi
        //public NhanVien(string ten)
        //{
        //    Ten = ten;
        //}
        public int ID { get; set; }
        public string Ten { get; set; }
       
    }
}
