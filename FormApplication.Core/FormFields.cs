using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FormApplication.Core
{
    public class FormFields
    {
        public bool Required { get; set; } 
        public string Name { get; set; } 
        public string DataType { get; set; }
    }
}
