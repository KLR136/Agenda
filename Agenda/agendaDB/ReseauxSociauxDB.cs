using System;
using System.Collections.Generic;

namespace agenda.agendaDB;

public partial class ReseauxSociauxDB
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<ProfilDesRéseauxDB> ProfilDesRéseauxes { get; set; } = new List<ProfilDesRéseauxDB>();
}
