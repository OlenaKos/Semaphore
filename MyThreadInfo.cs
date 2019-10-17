using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Semafor
{
    class MyThreadInfo
    {
        static int ThreadIDCounter = 0;
        public int ThreadID { set; get; }
        public int Counter { set; get; }
        public bool isWorking { set; get; }
        public bool isWaiting { set; get; }

        public MyThreadInfo()
        {
            ThreadID = ThreadIDCounter++;
            Counter = 0;
            isWorking = false;
            isWaiting = false;
            
        }

        public void SetWaiting (){
            isWorking = false;
            isWaiting = true;
        }
        public void SetWorking() {
            isWorking = true;
            isWaiting = false;
        }
        public string InfoToString()
        {
            string Status = isWorking ? $"{Counter}" : isWaiting ? "waiting" : "created";
            return $"Thread {ThreadID} -> {Status}";
        }
        public void Run()
        {
            while (isWorking)
            {
                Counter++;
                
                Thread.Sleep(1000);

            }
        }
    }
}
