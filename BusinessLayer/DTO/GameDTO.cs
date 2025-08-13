using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BusinessLayer.DTO
{
    public class GameDTO
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateOnly? ReleaseDate { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }  
    }
}
