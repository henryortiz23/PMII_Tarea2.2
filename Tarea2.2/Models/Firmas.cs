using SQLite;

namespace Tarea2._2.Models
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public byte[] firma { get; set; }

        [MaxLength(50)]
        public string descripcion { get; set; }
    }
}