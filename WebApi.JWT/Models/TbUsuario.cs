using System;
using System.Collections.Generic;

namespace WebApi.JWT.Models;

public partial class TbUsuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }
}
