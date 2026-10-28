using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventariosmvc.Models;

[Table("Marca")] // <--- Agrega esta línea
public partial class Marca
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}