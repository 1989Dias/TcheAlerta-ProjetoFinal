using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TcheAlerta.Data;
using TcheAlerta.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConexaoDBSqLite))]
namespace TcheAlerta.Droid.Data
{
    class ConexaoDBSqLite : IConexaoDBSqLite
    {
        public string Conexao(string NomeArquivoBD) {
            string stringConexao = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string bancoDados = Path.Combine(stringConexao, NomeArquivoBD);
            return bancoDados;
        }
    }
}