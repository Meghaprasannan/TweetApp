using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace test.DAOLayer.Entities
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Body { get; set; }

        public DateTime postedDate { get; set; } = DateTime.Now;
    }
}
