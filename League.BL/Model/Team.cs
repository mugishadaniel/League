namespace League.BL.Model
{
    public class Team
    {
        //moet internal zijn
        public Team(int stamNummer, string naam)
        {
            ZetStamNummer(stamNummer);
            ZetNaam(naam);
        }

        public int StamNummer { get; private set; }

        public string Naam { get; private set; }

        public string BijNaam { get; private set; }

        private List<Speler> _spelers = new List<Speler>();
        public IReadOnlyList<Speler> Spelers()
        {
            return _spelers.AsReadOnly(); 
        }

        public bool HeeftSpeler(Speler speler)
        {
            return _spelers.Contains(speler);
        }

        public void VoegSpelerToe(Speler speler)
        {
            if (speler == null)
            {
                throw new Exceptions.TeamException("voegspelertoe");
            }
            if (_spelers.Contains(speler))
            {
                throw new Exceptions.TeamException("Speler is al toegevoegd");
            }
            _spelers.Add(speler);
            if (speler.Team != this)
            {
                speler.ZetTeam(this);
            }
      


        }

        public void VerwijderSpeler(Speler speler)
        {
            if (speler == null)
            {
                throw new Exceptions.TeamException("verwijderspeler");
            }
            if (!_spelers.Contains(speler))
            {
                throw new Exceptions.TeamException("Speler is niet toegevoegd");
            }
            _spelers.Remove(speler);
            if (speler.Team == this)
            {
                speler.VerwijderTeam();
            }
            
        }

        public void ZetStamNummer(int stamNummer)
        {
            if (stamNummer <= 0)
            {
                throw new Exceptions.TeamException("Stamnummer moet groter zijn dan 0");
            }
            StamNummer = stamNummer;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new Exceptions.TeamException("Naam is verplicht");
            }
            Naam = naam.Trim();
        }

        public void ZetBijNaam(string bijNaam)
        {
            if (string.IsNullOrWhiteSpace(bijNaam))
            {
                throw new Exceptions.TeamException("Bijnaam is verplicht");
            }
            BijNaam = bijNaam.Trim();
        }

        public override bool Equals(object? obj)
        {
            return obj is Team team &&
                   StamNummer == team.StamNummer;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StamNummer);
        }
    }
}