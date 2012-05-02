using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamPortal.Web.Models;
using System.IO;

namespace TeamPortal.Web.Controllers
{   
    public class RosterController : Controller
    {
		private readonly ITeamRepository teamRepository;
		private readonly IPlayerRepository playerRepository;
        private readonly IStateRepository stateRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public RosterController() : this(new TeamRepository(), new PlayerRepository(), new StateRepository())
        {
        }

        public RosterController(ITeamRepository teamRepository, IPlayerRepository playerRepository, IStateRepository stateRepository)
        {
			this.teamRepository = teamRepository;
			this.playerRepository = playerRepository;
            this.stateRepository = stateRepository;
        }

        public ViewResult Index()
        {
            int teamId = (int)this.Session["TeamId"];
            return View(playerRepository.All.Where(p => p.TeamId == teamId));
        }

        public ViewResult Details(int id)
        {
            return View(playerRepository.Find(id));
        }

        public ActionResult Create()
        {
			ViewBag.PossibleTeams = teamRepository.All;
            ViewBag.States = this.stateRepository.GetStates();
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid) {
                AddPostedFiles(player);
                playerRepository.InsertOrUpdate(player);
                playerRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTeams = teamRepository.All;
                ViewBag.States = this.stateRepository.GetStates();
				return View();
			}
        }
        
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleTeams = teamRepository.All;
            ViewBag.States = this.stateRepository.GetStates();
            return View(playerRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid) {
                AddPostedFiles(player);
                playerRepository.InsertOrUpdate(player);
                playerRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTeams = teamRepository.All;
                ViewBag.States = this.stateRepository.GetStates();
				return View();
			}
        }

        public ActionResult Delete(int id)
        {
            return View(playerRepository.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            playerRepository.Delete(id);
            playerRepository.Save();

            return RedirectToAction("Index");
        }

        #region Private Methods

        private void AddPostedFiles(Player player)
        {
            if (Request.Files.Count > 0)
            {
                // assume only 1 file posted
                HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;

                if (hpf.ContentLength == 0)
                    return;
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(hpf.FileName);
                string serverFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "roster-images", newFileName);
                hpf.SaveAs(serverFileName);
                player.PhotoUri = "/roster-images/" + newFileName;
            }
        }

        #endregion
    }
}

