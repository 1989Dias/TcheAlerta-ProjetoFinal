using SQLite;
using System;

namespace TcheAlerta.Models
{
    public class Alerta
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Titulo { get; set; }

        [MaxLength(50)]
        public string Observacao { get; set; }       
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
