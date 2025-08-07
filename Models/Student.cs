using System;
using System.Collections.Generic;

namespace ASPCoreWebAPICRUD.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentGender { get; set; }

    public decimal? Age { get; set; }

    public string? Class { get; set; }

    public string? FatherName { get; set; }
}
