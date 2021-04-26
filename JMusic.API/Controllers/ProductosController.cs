﻿using JMusic.Data;
using JMusic.Data.Interfaces;
using JMusic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _repository;
        public ProductosController(IProductosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            try
            {
                return await _repository.ObtenerProductosAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Producto>> GetProducto(int Id)
        {
            var producto = await _repository.ObtenerProductoAsync(Id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            try
            {
                var nuevoProducto = await _repository.Agregar(producto);
                if (nuevoProducto == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(PostProducto), new { Id = nuevoProducto.Id }, producto);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> PutProducto(int Id, [FromBody] Producto producto)
        {
            if (producto == null)
            {
                return NotFound();
            }
            var resultado = await _repository.Actualizar(producto);
            if (!resultado)
            {
                return BadRequest();
            }
            return producto;

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteProducto(int Id)
        {
            try
            {
                var resultado = await _repository.Eliminar(Id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
