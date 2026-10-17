using LegacyApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace LegacyApp.Repositories
{
    public class OrderRepository
    {
        private string connectionString;

        public OrderRepository()
        {
            connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
        }

        public ArrayList GetOrders()
        {
            ArrayList orders = new ArrayList();

            DataTable table = new DataTable();

            // Pretend this came from SQL Server
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("Amount", typeof(decimal));
            table.Columns.Add("Status", typeof(string));

            table.Rows.Add(1, "Manoj", 1500, "Pending");
            table.Rows.Add(2, "Rahul", 2300, "Completed");
            table.Rows.Add(3, "Amit", 850, "Pending");

            foreach (DataRow row in table.Rows)
            {
                Order order = new Order();

                order.Id = Convert.ToInt32(row["Id"]);
                order.CustomerName = row["CustomerName"].ToString();
                order.Amount = Convert.ToDecimal(row["Amount"]);
                order.Status = row["Status"].ToString();

                orders.Add(order);
            }

            return orders;
        }
    }
}
