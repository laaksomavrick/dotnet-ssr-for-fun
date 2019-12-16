using System;
using System.ComponentModel.DataAnnotations;

namespace SsrExample.Models
{
    public class Folder
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
    }
}