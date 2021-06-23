using System;

namespace TcheAlerta
{
    public class Util
    {       
        public Double GetSegundos(DateTime dataAtual, TimeSpan horaAtual, DateTime dataAlerta, TimeSpan horaAlerta) {
            DateTime dt1 = dataAtual.Add(horaAtual);
            DateTime dt2 = dataAlerta.Add(horaAlerta);

            return dt2.Subtract(dt1).TotalSeconds;
        }
    }
}
