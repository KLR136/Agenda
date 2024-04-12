using System;
using System.Collections.Generic;

namespace agenda.agendaDB;

public partial class TaskDB
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public byte[]? Check { get; set; }

    public int ToDoListId { get; set; }

    public virtual ToDoListDB ToDoList { get; set; } = null!;
}
