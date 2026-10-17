using LegacyApp.Models;
using LegacyApp.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace LegacyApp.Services
{
    public class OrderService
    {
        private OrderRepository repository;

        public OrderService()
        {
            repository = new OrderRepository();
        }

        public string ProcessOrders()
        {
            ArrayList orders = repository.GetOrders();

            Hashtable result = new Hashtable();

            foreach (Order order in orders)
            {
                try
                {
                    if (order.Status == "Pending")
                    {
                        bool success = SendOrderToExternalSystem(order);

                        if (success)
                        {
                            order.Status = "Completed";
                        }
                        else
                        {
                            order.Status = "Failed";
                        }
                    }

                    result[order.Id] = order.Status;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "Error processing order " +
                        order.Id +
                        ": " +
                        ex.Message);

                    result[order.Id] = "Error";
                }
            }

            return JsonConvert.SerializeObject(result);
        }

        private bool SendOrderToExternalSystem(Order order)
        {
            WebClient client = new WebClient();

            client.Headers.Add(
                HttpRequestHeader.ContentType,
                "application/json");

            string json = JsonConvert.SerializeObject(order);

            try
            {
                string response = client.UploadString(
                    "https://example.com/api/orders",
                    "POST",
                    json);

                Thread.Sleep(1000);

                return response.Contains("success");
            }
            catch (WebException ex)
            {
                Console.WriteLine(
                    "External API failed: " +
                    ex.Message);

                return false;
            }
        }
    }
}
