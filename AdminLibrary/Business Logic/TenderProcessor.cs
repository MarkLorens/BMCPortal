using AdminLibrary.Models;
using AdminLibrary.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLibrary.Business_Logic
{
    public static class TenderProcessor
    {
        public static int createTender (string instansi, string alamat, string no_kontak, string email)
        {
            TenderModel data = new TenderModel
            {
                instansi = instansi,
                alamat = alamat,
                no_kontak = no_kontak,
                email = email,
            };

            string sql = @"INSERT INTO dbo.Tender (instansi, alamat, no_kontak, email) 
                        VALUES (@instansi, @alamat, @no_kontak, @email);";
            return SqlDataAccess.SaveData(sql,data);
        }
        
        public static List<TenderModel> LoadTender()
        {
            string sql = @"SELECT instansi, alamat, no_kontak, email FROM dbo.Tender;";
            return SqlDataAccess.LoadData<TenderModel>(sql);
        }
    }
}
