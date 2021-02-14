using AdminLibrary.Data_Access;
using AdminLibrary.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;

namespace AdminLibrary.Business_Logic
{
    public static class StockProcessor
    {
        public static int createStock(int id, string item, float stock, int amt_modified, DateTime last_modified, 
                                        string modified_by, string brand, float price, float stock_before)
        {
            StockModel data = new StockModel
            {
                id = id,
                item = item,
                stock = stock,
                amt_modified = amt_modified,
                last_modified = last_modified,
                modified_by = modified_by,
                brand = brand,
                price = price,
                stock_before = stock_before
            };

            string sql = @"INSERT INTO Stock (id, item, stock, amt_modified, last_modified, modified_by, brand, price, stock_before)
                            VALUES (@id, @item, @stock, @amt_modified, @last_modified, @modified_by, @brand, @price, @stock_before);";

            return SqlDataAccess.SaveData(sql,data);
        }
        public static List<StockModel> LoadStock()
        {
            string sql = @"SELECT id, item, stock, amt_modified, last_modified, modified_by, brand, price, stock_before
                            FROM Stock;";
            return SqlDataAccess.LoadData<StockModel>(sql);
        }

        public static int UpdateStockBefore(float stock, string item)
        {
            StockModel data = new StockModel
            {
                stock = stock,
                item = item
            };
            string sql = @"UPDATE Stock SET stock_before=@stock WHERE item=@item;";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static int UpdateStockByAddStock(float stock, int amt_modified, DateTime last_modified, string item)
        {
            StockModel data = new StockModel
            {
                stock = stock,
                amt_modified = amt_modified,
                last_modified = last_modified,
                item = item
            };
            string sql = @"UPDATE Stock SET stock=@stock WHERE item=@item;
                           UPDATE Stock SET amt_modified=@amt_modified WHERE item=@item;
                           UPDATE Stock SET last_modified=@last_modified WHERE item=@item;";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
