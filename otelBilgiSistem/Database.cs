using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace otelBilgiSistem
{
    class Database
    {
        protected MySqlConnection mainDatabeseConn = new MySqlConnection("Server=localhost;Database=otelbilgisistemi;Uid=root;Pwd='';");
        public void mainConnect()
        {
            try
            {
                if (mainDatabeseConn.State == ConnectionState.Closed)
                {
                    mainDatabeseConn.Open();
                }
                else
                {
                    mainDatabeseConn.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata  " + err.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
