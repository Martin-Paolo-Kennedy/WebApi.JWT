using System;
using System.Collections.Generic;

namespace WebApi.JWT.Models;

public partial class TbProducto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public decimal? Precio { get; set; }

    public bool Estado { get; set; } 
}
