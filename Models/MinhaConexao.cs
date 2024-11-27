using System.Data.SQLite;

namespace WebApplication1.Models
{
    public static class Conexao
    {
        public static SQLiteConnection Nova()
        {
            String stringConnection = "Data Source=imobiliaria.db; Version = 3; New = True; Compress = True; ";
            return new SQLiteConnection(stringConnection);
        }
    }
}
