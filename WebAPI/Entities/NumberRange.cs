using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class NumberRange
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Description - Please enter no more than 50 characters.")]
        public string Description
        {
            get; set;
        }

        [Required]
        public int EndNumber
        {
            get; set;
        }

        [Required]
        public int LastNumber
        {
            get; set;
        }

        [Required]
        [StringLength(100, ErrorMessage = "Number Range Code - Please enter no more than 100 characters.")]
        public string NumberRangeCode
        {
            get; set;
        }

        [Required]
        [StringLength(7, ErrorMessage = "Prefix - Please enter no more than 7 characters.")]
        public string Prefix
        {
            get; set;
        }

        [Required]
        public int StartNumber
        {
            get; set;
        }
        public DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
