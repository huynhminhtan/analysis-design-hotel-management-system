using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Class1
    {
        public static void PrintTest()
        {

            DTO.Class1.PrintTest();
            DAO.Class1.PrintTest();

            Console.WriteLine("test BUS");
            return;
        }
    }
}
