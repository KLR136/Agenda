using System;
using System.Collections.Generic;

namespace agenda.agendaDB;

public partial class ProfilDesRéseauxDB
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public int ReseauxSociauxId { get; set; }

    public virtual ContactDB Contact { get; set; } = null!;

    public virtual ReseauxSociauxDB ReseauxSociaux { get; set; } = null!;
}
