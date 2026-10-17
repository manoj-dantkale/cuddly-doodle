using LegacyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegacyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                OrderService service = new OrderService();

                string result = service.ProcessOrders();

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Application error: " +
                    ex.Message);
            }

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
