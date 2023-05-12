using League.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.BL.Model
{
    public class Speler
    {
        //moet allemaal internal zijn
        public Speler(string naam, int? lengte, int? gewicht)
        {
            ZetNaam(naam);
            if (lengte !=null) ZetLengte(lengte.Value);
            if (gewicht != null) ZetGewicht(gewicht.Value);
        }

        public Speler(int id, string naam, int? lengte, int? gewicht) : this(naam, lengte, gewicht)
        {
            ZetId(id);
        }

        public int Id { get;private set; }

        public string Naam { get;private set; }
        
        public int? RugNummer { get;private set; }
        
        public int? Lengte { get;private set; }
        
        public int? Gewicht { get;private set; }

        public Team Team { get;private set; }

        public void VerwijderTeam()
        {
            if (Team == null) { throw new Exceptions.SpelerException("Speler heeft geen team");}
            Team = null;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new Exceptions.SpelerException("Naam is verplicht");
            }
            Naam = naam.Trim();
        }

        public void ZetLengte(int lengte)
        {
            if (lengte < 150)
            {
                throw new Exceptions.SpelerException("Lengte moet groter zijn dan 150");
            }
            Lengte = lengte;
        }

        public void ZetGewicht(int gewicht)
        {
            if (gewicht < 50)
            {
                throw new Exceptions.SpelerException("Gewicht moet groter zijn dan 50");
            }
            Gewicht = gewicht;
        }

        public void ZetId(int id)
        {
            if (id <= 0)
            {
                throw new Exceptions.SpelerException("Id moet groter zijn dan 0");
            }
            Id = id;
        }

        public void ZetRugNummer(int rugNummer)
        {
            if (rugNummer <= 0 || rugNummer > 99)
            {
                throw new Exceptions.SpelerException("Rugnummer moet tussen 1 en 99 liggen");
            }
            RugNummer = rugNummer;
        }

        public void ZetTeam(Team team)
        {
            if (team == null) throw new SpelerException("zetteam- team is null");
            if (Team == team) throw new SpelerException("zetteam - zelfde team");
            if (Team != null)
            {
                if (Team.HeeftSpeler(this)) Team.VerwijderSpeler(this);
            }
            if (!team.HeeftSpeler(this))
            {
                Team = team;
                team.VoegSpelerToe(this);
            }


        }

        public override bool Equals(object? obj)
        {
            return obj is Speler speler &&
                   Id == speler.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
