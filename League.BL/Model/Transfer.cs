using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.BL.Model
{
    public class Transfer
    {
        public Transfer(Speler speler, Team oudTeam)
        {
            ZetSpeler(speler);
            ZetOudTeam(oudTeam);
        }

        public Transfer(Speler speler, Team nieuweTeam, int prijs) : this(speler, nieuweTeam)
        {
            ZetPrijs(prijs);
            ZetSpeler(speler);
            ZetNieuweTeam(nieuweTeam);
        }

        public Transfer(Speler speler, Team nieuweTeam, Team oudTeam, int prijs)
        {
            ZetOudTeam(oudTeam);
        }

        public Transfer(int id, Speler speler, Team nieuweTeam, Team oudTeam, int prijs)
        {
            ZetId(id);
            ZetSpeler(speler);
            ZetNieuweTeam(nieuweTeam);
            ZetOudTeam(oudTeam);
            ZetPrijs(prijs);
        }

        public int Id { get; private set; }
        public Speler Speler { get; private set; }
        public Team NieuweTeam { get; private set; }
        public Team OudTeam { get; private set; }
        public int Prijs { get; private set; }

        public void ZetId(int id)
        {
            if (id < 0)
            {
                throw new Exceptions.TransferException("Id moet groter zijn dan 0");
            }
            Id = id;
        }

        public void ZetPrijs(int prijs)
        {
            if (prijs < 0)
            {
                throw new Exceptions.TransferException("Prijs moet groter zijn dan 0");
            }
            Prijs = prijs;
        }

        public void VerwijderOudTeam()
        {
            if(NieuweTeam is null) throw new Exceptions.TransferException("Nieuwe team is verplicht");
            OudTeam = null;

        }

        public void ZetOudTeam(Team team)
        {
            if (team is null) throw new Exceptions.TransferException("Oud team is verplicht");
            if(team== NieuweTeam) throw new Exceptions.TransferException("Oud team mag niet hetzelfde zijn als nieuwe team");
            OudTeam = team;
        }

        public void VerwijderNieuweTeam()
        {
            if (OudTeam is null) throw new Exceptions.TransferException("Oud team is verplicht");
            NieuweTeam = null;
        }

        public void ZetNieuweTeam(Team team)
        {
            if (team is null) throw new Exceptions.TransferException("Nieuwe team is verplicht");
            if (team == OudTeam) throw new Exceptions.TransferException("Nieuwe team mag niet hetzelfde zijn als oude team");
            NieuweTeam = team;
        }

        public void ZetSpeler(Speler speler)
        {
            if (speler is null) throw new Exceptions.TransferException("Speler is verplicht");
            Speler = speler;
        }   
    }
}
