using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PostCommentExample.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime dtComment { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime dtPublish { get; set; }

        [Required(ErrorMessage ="Required field")]
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [StringLength(1500)]
        [Required]
        public string sComment { get; set; }

        [StringLength(150)]
        [Required]
        public string sAuthor { get; set; }
    }
}
