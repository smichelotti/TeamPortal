using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TeamPortal.Web.Models
{ 
    public class StateRepository : IStateRepository
    {
        TeamPortalWebContext context = new TeamPortalWebContext();

        public List<State> GetStates()
        {
            return context.States.ToList();
        }
    }

    public interface IStateRepository
    {
        List<State> GetStates();
    }
}