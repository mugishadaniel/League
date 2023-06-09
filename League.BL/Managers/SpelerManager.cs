﻿using League.BL.Exceptions;
using League.BL.Interfaces;
using League.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.BL.Managers
{
    public class SpelerManager
    {
        private ISpelerRepository repo;

        public SpelerManager(ISpelerRepository repo)
        {
            this.repo = repo;
        }

        public Speler RegistreerSpeler(string naam, int? lengte,int? gewicht)
        {
            try
            {
                Speler s = new Speler(naam, lengte, gewicht);
                if (!repo.BestaatSpeler(s))
                {
                    s = repo.SchrijfSpelerInDB(s);
                    return s;
                }
                else
                    throw new SpelerManagerException("Registreerspeler");
            }
            catch(SpelerManagerException e) { throw; }
            catch(Exception e)
            {
                throw new SpelerManagerException("Registreerspeler", e);
            }
        }

        public void UpdateSpeler(Speler speler)
        {
            try
            {
                if (repo.BestaatSpeler(speler))
                {
                    repo.UpdateSpeler(speler);
                }
                else
                    throw new SpelerManagerException("UpdateSpeler");
            }
            catch (SpelerManagerException e) { throw; }
            catch (Exception e)
            {
                throw new SpelerManagerException("UpdateSpeler", e);
            }
        }
    }
}
