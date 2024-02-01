using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Team;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class TeamController : MainController
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _teamService.GetAllAsync());
        }


		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			TeamVM team = await _teamService.GetByIdAsync((int)id);

			if (team is null) return RedirectToAction("Index", "Error");

			return View(team);
		}





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamCreateVM request)

        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            if (!request.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File can be only image format");
                return View();
            }

            if (!request.Photo.CheckFileSize(500))
            {
                ModelState.AddModelError("Photo", "File size can be max 500 kb");
                return View();
            }

            await _teamService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            TeamVM team = await _teamService.GetByIdAsync((int)id);

            if (team is null) return NotFound();

            TeamEditVM teamEditVM = _mapper.Map<TeamEditVM>(team);

            return View(teamEditVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, TeamEditVM request)
        {
            if (id is null) return BadRequest();

            TeamVM dbTeam = await _teamService.GetByIdAsync((int)id);

            if (dbTeam is null) return NotFound();


            request.Image = dbTeam.Image;

            if (!ModelState.IsValid)
            {
                return View(request);

            }

            if (request.Photo is not null)
            {
                if (!request.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File can be only image format");
                    return View(request);
                }
                if (!request.Photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "File size can be max 500 kb");
                    return View(request);
                }
            }


            await _teamService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }



    }
}
