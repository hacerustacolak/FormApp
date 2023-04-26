using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FormApplication.Data.DomainClass
{
    public class FormDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FormId { get; set; }
        public bool Required { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(50)]
        public string DataType { get; set; }
    }
}
