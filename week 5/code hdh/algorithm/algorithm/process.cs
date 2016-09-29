using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm
{
    public class Process
    {
        public int pid { get; set; }// ma tien trinh
        public string pname { get; set; }// ten tien trinh
        public int tarrive { get; set; }// thoi diem vao ready list
        public int burst { get; set; }// thoi gian xu ly
        public int priority { get; set; }// do uu tien
    }
}
