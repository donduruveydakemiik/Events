using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class Program
    {
        public delegate void StockControl();
        static void Main(string[] args)
        {
            Product hardDisk= new Product(50);
            hardDisk.Name = "Hard Disk";
            Product gsm = new Product(50);
            gsm.Name = "Gsm";

            gsm.StockControlEvent += Gsm_StockControlEvent;

            for (int i = 0; i < 10; i++)
            {
                hardDisk.Sell(10);
                gsm.Sell(10);

                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void Gsm_StockControlEvent()
        {
            Console.WriteLine("GSM BİTMEK ÜZERE DİKKAT!!!");
        }

        public class Product
        {
            int _stock;
            public Product(int stock)
            {
                _stock = stock;
            }
            public event StockControl StockControlEvent;
            public string Name { get; set; }
            public int Stock 
            {
                get
                {
                    return _stock;
                }

                set
                {
                    _stock= value;
                    if (Stock<=15 &&StockControlEvent != null) 
                    {

                        StockControlEvent();
                    }
                } 
            }

            public void Sell(int amount)
            {
                Stock -= amount;
                Console.WriteLine("{0} = {1}",Name, Stock);
            }

        }
    }
}
