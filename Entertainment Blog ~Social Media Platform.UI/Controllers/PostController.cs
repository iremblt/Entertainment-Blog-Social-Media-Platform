using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IContentsService _contentsService;
        public PostController(IPostService postService,ICategoryService categoryService,ITagService tagService,IContentsService contentsService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _contentsService = contentsService;
        }       
        public async Task<IActionResult> Details(int id)
        {
            var detail = await _postService.GetNextAndLastPostOfThePostAsync(id);
            return View(detail);
        }
        [HttpGet]
        public async Task<IActionResult> CreatePost()
        {
            var post = new AddingPostTagsCategoryDTO()
            {
                CategoryList = await _categoryService.GetCategoriesAsync(),
                TagList = await _tagService.GetTagsAsync()
            };
            return View(post);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(AddingPostTagsCategoryDTO post)
        {
            if (ModelState.IsValid)
            {
                var added= await _postService.AddPostAsync(post.PostAdd);
                return RedirectToAction("CreateContent", "Post",new {postid=added.Id});
            }
            return View(post);
        }
        [HttpGet]
        public async Task<IActionResult> CreateContent(int postid)
        {
            var contentesAdd = new ContentsAddDTO()
            {
                PostId = postid,
                Post = await _postService.GetPostByIdAsync(postid)
            };
            return View(contentesAdd);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContent(ContentsAddDTO contents)
        {
            if (ModelState.IsValid)
            {
                await _contentsService.AddContentsAsync(contents);
                if (contents.AddMoreContent==true)
                {
                    return RedirectToAction("CreateContent", "Post", new { postid = contents.PostId });
                }
                else
                {
                    return RedirectToAction("Details", "Post", new { id = contents.PostId });
                }
            }
            return View(contents);
        }
        [HttpPost]
        //Eğer tag'in adı daha önce bulunuyorsa ekleme! Service ekledim Fluent Api olarak eklersin ileride
        public async Task<IActionResult> CreateTag(TagAddOrEditDTO tag)
        {
            if (ModelState.IsValid)
            {
                await _tagService.AddOrEditTagAsync(tag);
            }
            return RedirectToAction("CreatePost");
        }
        [HttpGet]
        public IActionResult EditPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditPost(PostEditDTO postEdit)
        {
            return View(postEdit);
        }        
        [HttpGet]
        public IActionResult DeletePost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeletePost(PostDeleteDTO postDelete)
        {
            return View(postDelete);
        }

    }
}
