using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_vue_test_back.Entities.Tables
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("fio")]
        public string FIO { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("phone")]
        public string Phone { get; set; }
    }
}
