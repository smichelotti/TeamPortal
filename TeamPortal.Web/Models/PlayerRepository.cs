using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TeamPortal.Web.Models
{ 
    public class PlayerRepository : IPlayerRepository
    {
        TeamPortalWebContext context = new TeamPortalWebContext();

        public IQueryable<Player> All
        {
            get { return context.Players; }
        }

        public IQueryable<Player> AllIncluding(params Expression<Func<Player, object>>[] includeProperties)
        {
            IQueryable<Player> query = context.Players;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Player Find(int id)
        {
            return context.Players.Find(id);
        }

        public void InsertOrUpdate(Player player)
        {
            if (player.Id == default(int)) {
                // New entity
                context.Players.Add(player);
            } else {
                // Existing entity
                context.Entry(player).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var player = context.Players.Find(id);
            context.Players.Remove(player);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IPlayerRepository
    {
        IQueryable<Player> All { get; }
        IQueryable<Player> AllIncluding(params Expression<Func<Player, object>>[] includeProperties);
        Player Find(int id);
        void InsertOrUpdate(Player player);
        void Delete(int id);
        void Save();
    }
}