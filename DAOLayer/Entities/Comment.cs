using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace test.DAOLayer.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Commment { get; set; }
    }
}
