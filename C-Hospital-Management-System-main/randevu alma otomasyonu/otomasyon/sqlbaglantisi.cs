﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace otomasyon
{
    class sqlbaglantisi
    {
       public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=CASPER_\\SQLEXPRESS;Initial Catalog=otomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
