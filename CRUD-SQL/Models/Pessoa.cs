using System.ComponentModel.DataAnnotations;

namespace CRUD_SQL.Models
{
    public class Pessoa
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string MaritalStatus { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
