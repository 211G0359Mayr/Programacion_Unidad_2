using System;
using System.Collections.Generic;

namespace Programacion_Unidad_2.Models;

public partial class Materias
{
    public uint Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public sbyte HorasTeoricas { get; set; }

    public sbyte HorasPracticas { get; set; }

    public byte Creditos { get; set; }

    public byte Semestre { get; set; }

    public int IdCarrera { get; set; }

    public virtual Carreras IdCarreraNavigation { get; set; } = null!;
}
