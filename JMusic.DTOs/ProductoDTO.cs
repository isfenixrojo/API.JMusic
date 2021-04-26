﻿using System.ComponentModel.DataAnnotations;

namespace JMusic.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [Display(Name = "Producto")]
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}