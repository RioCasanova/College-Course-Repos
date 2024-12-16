﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HogWildSystem.Entities;

[Table("Category")]
internal partial class Category
{
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [StringLength(30)]
    [Unicode(false)]
    public string CategoryName { get; set; }

    public bool RemoveFromViewFlag { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Lookup> Lookups { get; set; } = new List<Lookup>();
}