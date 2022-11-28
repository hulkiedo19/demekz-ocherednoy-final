using System;
using System.Collections.Generic;

namespace dima_pozarnik.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public int EquipmentCount { get; set; }

    public string EquipmentType { get; set; } = null!;
}
