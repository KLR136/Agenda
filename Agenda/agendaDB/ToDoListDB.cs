using System;
using System.Collections.Generic;

namespace agenda.agendaDB;

public partial class ToDoListDB
{
    public int Id { get; set; }

    public string? Titre { get; set; }

    public DateOnly? Date { get; set; }

    public DateOnly? DateFin { get; set; }

    public byte[]? Mask { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TaskDB> Tasks { get; set; } = new List<TaskDB>();
}
