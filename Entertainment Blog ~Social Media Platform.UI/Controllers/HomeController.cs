using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.SearchDTO;
using Entertainment_Blog__Social_Media_Platform.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(SearchDTO search)
        {
            var lists = _postService.GetPostsOrderByDateTime();
            if (search.Text != null)
            {
                var searching= _postService.SearchPost(search);
                return View(searching.ToList());
            }
            else
            {
                return View(lists);
            }
        }                 
        public IActionResult Privacy()
        {
            return View();
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
