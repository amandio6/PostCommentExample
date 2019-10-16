using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PostCommentExample.Models
{
    public class Post 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string sTitle { get; set; }
        [StringLength(2500)]
        [Required]
        public string sPost { get; set; }
        [StringLength(150)]
        [Required]
        public string sAuthor { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime dtRegist { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? dtPost { get; set; }
        public bool bCommentEnable { get; set; }

        public ICollection<Comment> Comments { get; set; }


    }
}
