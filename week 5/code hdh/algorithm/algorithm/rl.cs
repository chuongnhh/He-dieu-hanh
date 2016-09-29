using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm
{
    public class RL
    {
        public int num { get; set; }// so tien trinh dang co trong ready list
        public Queue<Process> m { get; set; }

        public RL()
        {
            m = new Queue<Process>();
        }
        //public bool init()
        //{
        //    //try
        //    //{
        //    //    m = Process
        //    //    for (int i = 0; i < num; i++)
        //    //    {
        //    //        m[i] = new Process();
        //    //    }
        //    //}
        //    //catch (Exception)
        //    //{

        //    //   return false;
        //    //}
        //    //return true;
        //}
    }
}
