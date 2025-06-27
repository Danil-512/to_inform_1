using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_to_inform
{
    [Table("Tg_user")]
    public class Tg_user
    {
        //Первичный ключ
        [Key]
        // Автоинкремент
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Tg_id { get; set; }

        public int Main_id { get; set; }

        [MaxLength(500)]
        public string Tg_username { get; set; }

        public DateTime Reg_date { get; set; } = DateTime.UtcNow;

        public string Tg_chat_id { get; set; }

    }
}
