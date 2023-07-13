using System;
using System.Runtime.InteropServices.JavaScript;

namespace MultiThreading 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            //int randomInteger = random.Next(2001);
            
            Job job1 = new Job("Job1", random);
            Job job2 = new Job("Job2", random);
            //Lancio i job in dei thread
            Thread th1 = new Thread(job1.DoWork);
            Thread th2 = new Thread(job2.DoWork);
            DateTime inizio = DateTime.Now;
            Console.WriteLine(inizio.ToLongTimeString());
            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();
            DateTime fine = DateTime.Now;
            Console.WriteLine(fine.ToLongTimeString());
            Console.WriteLine("Fine del main!");
        }
    }
}