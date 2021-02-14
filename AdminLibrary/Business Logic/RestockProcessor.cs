using AdminLibrary.Data_Access;
using AdminLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLibrary.Business_Logic
{
    public static class RestockProcessor
    {
        public static int CreateRestock(string order_ref, DateTime date_bought, string buyer, float amt_bought,
                                        float amt_spent, int id)
        {
            RestockModel data = new RestockModel
            {
                order_ref = order_ref,
                date_bought = date_bought.Date,
                buyer = buyer,
                amt_bought = amt_bought,
                amt_spent = amt_spent,
                id = id
            };
            string sql = @"INSERT INTO Restock(order_ref, date_bought, buyer, amt_bought, amt_spent, id)
                            VALUES (@order_ref, @date_bought, @buyer, @amt_bought, @amt_spent, @id);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<RestockModel> LoadRestock()
        {
            string sql = @"SELECT Restock.order_ref, Restock.date_bought, Restock.buyer, Restock.amt_bought, 
                          Restock.amt_spent, Stock.item
                          FROM Restock, Stock
                          WHERE Restock.id = Stock.id;";
            return SqlDataAccess.LoadData<RestockModel>(sql);
        }
    }
}
