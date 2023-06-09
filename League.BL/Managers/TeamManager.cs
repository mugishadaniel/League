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
    public class TeamManager
    {
        private ITeamRepository repo;
        public TeamManager(ITeamRepository repo)
        {
            this.repo = repo;
        }
        public void RegistreerTeam(int stamnummer, string naam,string bijnaam)
        {
            try
            {
                Team t = new Team(stamnummer, naam);
                if (!string.IsNullOrWhiteSpace(bijnaam)) t.ZetBijNaam(bijnaam);
                if (!repo.BestaatTeam(t))
                {
                    repo.SchrijfTeamInDB(t);
                }
                else
                {
                    throw new TeamManagerException("RegistreerTeam - Team bestaat al");
                }
            }
            catch(TeamManagerException) { throw; }
            catch(Exception ex)
            {
                throw new TeamManagerException("RegistreerTeam", ex);
            }
        }
        public Team SelecteerTeam(int stamnummer)
        {
            try
            {
                Team team=repo.SelecteerTeam(stamnummer);
                if (team == null) throw new TeamManagerException("Selecteerteam - team bestaat niet");
                return team;
            }
            catch(TeamManagerException) { throw; }
            catch (Exception ex)
            {
                throw new TeamManagerException("selecteerteam", ex);
            }
        }
        public void UpdateTeam(Team team)
        {
            try
            {
                if (repo.BestaatTeam(team))
                {
                    repo.UpdateTeam(team);
                }
                else
                {
                    throw new TeamManagerException("UpdateTeam - Team bestaat niet");
                }
            }
            catch(TeamManagerException) { throw; }
            catch (Exception ex)
            {
                throw new TeamManagerException("UpdateTeam", ex);
            }
        }
    }
}
