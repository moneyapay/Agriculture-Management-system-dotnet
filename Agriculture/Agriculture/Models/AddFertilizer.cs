//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agriculture.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class AddFertilizer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This Field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string Used { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string Price { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string Description { get; set; }
    }
}
