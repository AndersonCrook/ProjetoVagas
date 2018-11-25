using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace ProjetoVagas.Models
{
    [Table("Vagas")]
    public class Vagas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set;}
        public string JobTitle { get; set; }
        public short Quantity { get; set; }
        public string City { get; set; }
        public double Salary { get; set; }
        public string Description { get; set; }
        public string TypeOfHiring { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
