using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminLibrary.Data_Access;
using AdminLibrary.Models;

namespace AdminLibrary.Business_Logic
{
    public static class OrderProcessor
    {
        public static int createOrder(string order_ref, DateTime tgl_masuk,
            float dp, float sisa, float total, string pj, string instansi, int id, float bought_amt, string item_type, float stock_before)
        {
            OrderModel data = new OrderModel
            {
                order_ref = order_ref,
                tgl_masuk = tgl_masuk,
                dp = dp,
                sisa = sisa,
                total = total,
                pj = pj,
                instansi = instansi,
                id = id,
                bought_amt = bought_amt,
                item_type = item_type,
                stock_before = stock_before
            };
            string sql = @"INSERT INTO dbo.Orders (order_ref, tgl_masuk, dp,sisa, total, pj, instansi, id, bought_amt, item_type, stock_before) 
                        VALUES (@order_ref, @tgl_masuk, @dp, @sisa, @total, @pj, @instansi, @id, @bought_amt, @item_type, @stock_before);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int orderFinished(string order_ref, DateTime tgl_selesai)
        {
            OrderModel data = new OrderModel
            {
                order_ref = order_ref,
                tgl_selesai = tgl_selesai
            };
            string sql = @"UPDATE Orders SET tgl_selesai = @tgl_selesai WHERE order_ref=@order_ref";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<OrderModel> LoadOrder()
        {
            string sql = @"SELECT Orders.order_ref, Stock.item, Orders.tgl_masuk, Orders.tgl_selesai, 
                            Orders.dp, Orders.sisa, Orders.total, Orders.pj, Orders.instansi, Stock.id, Orders.bought_amt
                            FROM dbo.Orders, dbo.Stock
                            WHERE Orders.id = Stock.id
                            ORDER BY Orders.order_ref ASC;";

            return SqlDataAccess.LoadData<OrderModel>(sql);
        }

        public static int UpdateStockByOrder(float stock, int amt_modified, DateTime last_modified, string item)
        {
            StockModel data = new StockModel
            {
                stock = stock,
                amt_modified = amt_modified,
                last_modified = last_modified,
                item = item
            };

            string sql = @" UPDATE Stock SET stock=@stock WHERE item=@item;
                            UPDATE Stock SET amt_modified=@amt_modified WHERE item=@item;
                            UPDATE Stock SET last_modified=@last_modified WHERE item=@item;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
