using System;
using System.Collections.Generic;

namespace agenda.agendaDB;

public partial class ContactDB
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public DateOnly? Anniversaire { get; set; }

    public string? Genre { get; set; }

    public string? Telephone { get; set; }

    public string? Adresse { get; set; }

    public virtual ICollection<ProfilDesRéseauxDB> ProfilDesRéseauxes { get; set; } = new List<ProfilDesRéseauxDB>();
}
