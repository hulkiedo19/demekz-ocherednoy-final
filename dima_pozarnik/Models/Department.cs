using System;
using System.Collections.Generic;

namespace dima_pozarnik.Models;

public partial class Department
{
    public int Id { get; set; }

    public int EmployeeCount { get; set; }

    public string DepartmentName { get; set; } = null!;
}
