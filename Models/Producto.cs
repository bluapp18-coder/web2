using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventariosmvc.Models;

public partial class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    
    public int? IdMarca { get; set; }

    [ForeignKey("IdMarca")]
    public virtual Marca? IdMarcaNavigation { get; set; }
}
