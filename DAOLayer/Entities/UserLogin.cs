using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace test.DAOLayer.Entities
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime LogoutTime { get; set; }


    }
}
