using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Services
{
    public class ServiceConnection
    {
        
        SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=ESTOQUE;Integrated Security=True");
        

        public ServiceConnection(SqlConnection cn)
        {
            this.cn = cn;            
        }

        public static SqlConnection GetConnection()
        {
            return this.cn;
        }

        public string GetStringConnection()
        {
            return this.cn.ToString();
        }
    }

}
