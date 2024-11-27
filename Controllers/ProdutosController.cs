using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProdutosController : Controller
    {

		[HttpPost]
		public IActionResult Buscar()
        {
			SQLiteConnection? sqlite_conn = null;
            SQLiteDataReader? dr = null;
			try
            {
                sqlite_conn = Conexao.Nova();
                sqlite_conn.Open();

                string sql = $"select * from imovel";

                SQLiteCommand comandoSQL = new SQLiteCommand(sql, sqlite_conn);
                dr = comandoSQL.ExecuteReader();
                List<Imovel> list = new List<Imovel>();
                while (dr.Read())
                {
                    Imovel imovel = new Imovel();
                    imovel.Codigo = dr.GetInt32(0);
                    imovel.Foto   = dr.GetString(1);
                    imovel.Tipo   = dr.GetString(2);
					imovel.Desc = dr.GetString(2);
                    imovel.Valor  = dr.GetDouble(3);
                    list.Add(imovel);
                }
				dr.Close();
				sqlite_conn.Close();
				
				return Json(list);
            }
            catch (Exception ex)
            {
				if (dr != null)
				{
					dr.Close();
				}
				if (sqlite_conn != null)
				{
					sqlite_conn.Close();
				}
				return Json(new List<Imovel>());
            }
        }

		[HttpPost]
		public String Inserir(string foto, string tipo, string desc, double valor)
        {
			SQLiteConnection? sqlite_conn = null;
			try
            {
                sqlite_conn = Conexao.Nova();
                sqlite_conn.Open();
                string sql = $"insert into imovel(foto,tipo,valor, desc) values('{foto}','{tipo}', '{valor}' , '{desc}')";
                SQLiteCommand comandoSQL = new SQLiteCommand(sql, sqlite_conn);
                string resposta;
                if (comandoSQL.ExecuteNonQuery() > 0)
                {
                    resposta = "Dados inseridos com sucesso!!!";
                }
                else
                {
                    resposta = "Não foi possível inserir!!!";
                }
                sqlite_conn.Close();
                return resposta;
            }
            catch (Exception ex)
            {
				if (sqlite_conn != null)
				{
					sqlite_conn.Close();
				}
				return "Não foi possível inserir!!!";
            }
        }

        [HttpPost]
        public String Alterar(int codigo, string foto, string tipo, string desc, double valor)
        {
			SQLiteConnection? sqlite_conn = null;
			try
            {
                sqlite_conn = Conexao.Nova();
                sqlite_conn.Open();
                string sql = $"update imovel set foto='{foto}', tipo='{tipo}', valor='{valor}' , desc='{desc}' where codigo={codigo}";
                SQLiteCommand comandoSQL = new SQLiteCommand(sql, sqlite_conn);
                string resposta;
                if (comandoSQL.ExecuteNonQuery() > 0)
                {
                    resposta = "Dados alterados com sucesso!!!";
                }
                else
                {
                    resposta = "Não foi possível alterar!!!";
                }
                sqlite_conn.Close();
                return resposta;
            }
            catch (Exception ex)
            {
				if (sqlite_conn != null)
				{
					sqlite_conn.Close();
				}
				return "Não foi possível alterar!!!";
            }
        }


		[HttpPost]
		public String Excluir(int codigo)
        {
            SQLiteConnection ?sqlite_conn = null;
            try
            {
                sqlite_conn = Conexao.Nova();
                sqlite_conn.Open();
                string sql = $"delete from imovel where codigo={codigo}";
                SQLiteCommand comandoSQL = new SQLiteCommand(sql, sqlite_conn);
                string resposta;
                if (comandoSQL.ExecuteNonQuery() > 0)
                {
                    resposta = "Dados excluídos com sucesso!!!";
                }
                else
                {
                    resposta = "Não foi possível excluir!!!";
                }
                sqlite_conn.Close();
                return resposta;
            }
            catch (Exception ex)
            {
				if (sqlite_conn != null)
				{
					sqlite_conn.Close();
				}
				return "Não foi possível excluir!!!";
            }
        }
    }
}
