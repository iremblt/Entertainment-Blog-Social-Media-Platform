using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService tagService;
        public TagController(ITagService _tagService)
        {
            tagService = _tagService;
        }
        public async Task<IActionResult> TagList(TagViewListDTO tag)
        {
            var list = await tagService.GetTagsAsync();
            tag.TagLists = list;
            if (tag.Search!= null)
            {
                var searching = tagService.SearchTag(tag.Search).ToList();
                tag.TagLists = searching;
                return View(tag);
            }
                return View(tag);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> TagAdd(TagViewListDTO tag)
        {
            if (ModelState.IsValid)
            {
                await tagService.AddOrEditTagAsync(tag.TagAdd);
                tag.AddedName = tag.TagAdd.Name;
            }
            return RedirectToAction("TagList","Tag",tag);
        }
        [HttpPost]
        public async Task<IActionResult> TagDelete(TagViewListDTO tag)
        {
            var deleted = await tagService.GetTagsByIdAsync(tag.Id);
            await tagService.RemoveTagAsync(tag.Id);
            tag.DeletedName = deleted.Name;
            return RedirectToAction("TagList", "Tag", tag);
        }
        [HttpGet]
        public IActionResult TagEdit(int id)
        {
            var tag = tagService.GetEditTagsById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> TagEdit(TagAddOrEditDTO tagEdit)
        {
            if (ModelState.IsValid)
            {
                await tagService.AddOrEditTagAsync(tagEdit);
                return RedirectToAction("TagList", "Tag");
            }
            return View();
        }
    }
}
