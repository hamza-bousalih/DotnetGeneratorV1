using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using DotnetGenerator.Zynarator.Bean;

namespace DotnetGenerator.Zynarator.Audit;

public abstract class AuditBusinessObject : BusinessObject
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedOn { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime? UpdatedOn { get; set; }

    [StringLength(255)]
    public string CreatedBy { get; set; }

    [StringLength(255)]
    public string? UpdatedBy { get; set; }

    protected AuditBusinessObject()
    {
    }

    protected AuditBusinessObject(int id) : base(id)
    {
    }
}