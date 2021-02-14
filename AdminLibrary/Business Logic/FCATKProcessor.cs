using AdminLibrary.Data_Access;
using AdminLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLibrary.Business_Logic
{
    public static class FCATKProcessor
    {
        public static List<FCATKModel>LoadFCATK()
        {
            string sql = @"SELECT Orders.order_ref, Stock.item, Orders.tgl_masuk, Orders.stock_before, Orders.bought_amt, Orders.pj, Orders.item_type 
                            FROM Orders, Stock
                            WHERE Orders.id = Stock.id
                            ORDER BY Stock.item;";
            return SqlDataAccess.LoadData<FCATKModel>(sql);
        }
    }
}
