using SQLite;
using System;
using System.IO;
using System.Linq;
using TcheAlerta.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TcheAlerta.Data
{
    public class DBSqLite
    {
        public SQLiteConnection SqLiteConn { get; set; }

        public DBSqLite() {
            var dependencyService = DependencyService.Get<IConexaoDBSqLite>();

            string stringConexao = dependencyService.Conexao("TcheAlerta.sqlite");

            SqLiteConn = new SQLiteConnection(stringConexao);

            SqLiteConn.CreateTable<Alerta>();

            //SqLiteConn.DropTable<Alerta>();
        }
    }
}

