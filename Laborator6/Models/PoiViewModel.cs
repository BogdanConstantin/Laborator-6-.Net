using System.ComponentModel.DataAnnotations;

namespace Laborator6.Models
{
    using System;

    using Newtonsoft.Json;

    public class PoiViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 50, ErrorMessage = "The Name should be between 50 and 100 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "The Description should be shorter than 150 characters")]
        public string Description { get; set; }
    }
}
