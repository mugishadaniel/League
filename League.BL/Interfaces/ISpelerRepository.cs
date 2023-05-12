using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using League.BL.Model;

namespace League.BL.Interfaces
{
    public interface ISpelerRepository
    {
        bool BestaatSpeler(Speler s);
        Speler SchrijfSpelerInDB(Speler s);
        void UpdateSpeler(Speler speler);
    }
}
