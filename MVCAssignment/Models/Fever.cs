using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCAssignment.Model
{
    public class Fever
    {
        [Key]
        public float BodyTemperature { get; set; }


    }
}
