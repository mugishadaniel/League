using League.BL.Model;
using League.BL.Exceptions;

namespace TestDomain
{
    public class UnitTestSpeler
    {
        [Theory]
        [InlineData(1)]
        [InlineData(99)]
        public void ZetRugnummer_valid(int rugnr)
        {
            Speler s = new Speler(10,"Hans Vanaken", 190, 80);
            s.ZetRugNummer(rugnr);
            Assert.Equal(rugnr, s.RugNummer);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void ZetRugnummer_invalid(int rugnr)
        {
            Speler s = new Speler(10,"Hans Vanaken", 190, 80);
            Assert.Throws<SpelerException>(() => s.ZetRugNummer(rugnr));
        }

        [Theory]
        [InlineData("Jeff","Jeff")]
        [InlineData("Jeffrey","Jeffrey")]
        [InlineData("Jeffrey Van Acker","   Jeffrey Van Acker")]
        public void ZetNaam_valid(string naam, string expected)
        {
            Speler s = new Speler(10,"Hans Vanaken", 190, 80);
            s.ZetNaam(naam);
            Assert.Equal(expected, s.Naam);
        }

        [Theory]
        [InlineData(0,"Jos",150,80)]
        [InlineData(1," ",150,60)]
        public void ctor_withID_invalid (int id, string naam, int lengte, int gewicht)
        {
            Assert.Throws<SpelerException>(() => new Speler(id, naam, lengte, gewicht));
        }

        [Fact]
        public void VerwijderTeam_valid()
        {
            Speler s = new Speler(10,"Hans Vanaken", 190, 80);
            Team t = new Team(1, "Club Brugge");
            s.ZetTeam(t);
            s.VerwijderTeam();
            Assert.Null(s.Team);
            Assert.DoesNotContain(s, t.Spelers());
        }

        [Fact]
        public void ZetTeam_valid ()
        {
            Speler s = new Speler(10,"Hans Vanaken", 190, 80);
            Team t = new Team(1, "Club Brugge");
            s.ZetTeam(t);
            Assert.Equal(t, s.Team);
            Assert.Contains(s, t.Spelers());
        }

        [Fact]
        public void ZetTeam_invalid ()
        {
            Speler s = new Speler(10,"Hans Vanaken", 190, 80);
            Team t = new Team(1, "Club Brugge");
            s.ZetTeam(t);
            Assert.Throws<SpelerException>(() => s.ZetTeam(t));
        }

    }
}