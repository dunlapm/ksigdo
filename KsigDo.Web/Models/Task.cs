using System;
using System.ComponentModel.DataAnnotations;

namespace KsigDo.Web.Models
{
    public class Task
    {
        [Key]
        public int taskId { get; set; }

        [Required] [MaxLength(140)] [MinLength(10)]
        public string title { get; set; }

        public bool completed { get; set; }
        public DateTime lastUpdated { get; set; }

    }
}