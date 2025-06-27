using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_to_inform
{
    [Table("User")]
    public class User
    {
        // Первичный ключ
        [Key]
        // Автоинкремент
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public string Login { get; set; } = "";
        public DateTime Reg_date { get; set; } = DateTime.UtcNow;
    }
}
