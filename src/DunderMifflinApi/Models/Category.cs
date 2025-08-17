﻿using System;
using System.Collections.Generic;

namespace DunderMifflinApi.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
