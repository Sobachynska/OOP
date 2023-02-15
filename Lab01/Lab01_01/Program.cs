using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class DB
    {
        private string name;
        public string Name

        {
            get
            {
                return name;
            }
            set
            {
                name = value;

            }
        }

        private int prod;
        public int Prod

        {
            get
            {
                return prod;
            }
            set
            {
                prod = value;

            }
        }
        private uint selling;
        public uint Selling

        {
            get
            {
                return selling;
            }
            set
            {
                selling = value;

            }
        }
        private double marketpart;
        public double Marketpart

        {
            get
            {
                return marketpart;
            }
            set
            {
                marketpart = value;

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DB myObj = new DB();

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    myObj.Name = "Oracle";
                    myObj.Prod = 1;
                    myObj.Selling = 2500000000;
                    myObj.Marketpart = 31.01;
                    Console.WriteLine("Фiрма " + myObj.Name +"|" + " Кiлькiсть продуктiв " + myObj.Prod + "|" + " Рiчний об'єм продажу " + myObj.Selling + "|" + " Частина ринку " + myObj.Marketpart);
                }
                else if (i == 1)
                {
                    myObj.Name = "IBM";
                    myObj.Prod = 3;
                    myObj.Selling = 2400000000;
                    myObj.Marketpart = 29.25;
                    Console.WriteLine("Фiрма " + myObj.Name + "|" + " Кiлькiсть продуктiв " + myObj.Prod + "|" + " Рiчний об'єм продажу " + myObj.Selling + "|" + " Частина ринку " + myObj.Marketpart);
                }
                else
                {
                    myObj.Name = "Microsoft";
                    myObj.Prod = 2;
                    myObj.Selling = 1000000000;
                    myObj.Marketpart = 13.01;
                    Console.WriteLine("Фiрма " + myObj.Name + "|" + " Кiлькiсть продуктiв " + myObj.Prod + "|" + " Рiчний об'єм продажу " + myObj.Selling + "|" + " Частина ринку " + myObj.Marketpart);
                }
            }
        }
    }
}