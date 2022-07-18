using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Nesne_Benzin
{
    class Baglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-6GO1P98;Initial Catalog=nesne_benzin;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

    }
}
