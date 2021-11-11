using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
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
        [HttpPost,ValidateAntiForgeryToken]
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
        [HttpPost, ValidateAntiForgeryToken]
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
        public async Task<IActionResult> EditPost(int id)
        {
            var exits = _postService.GetEditPostByIdIncludeCategoriesAndTags(id);
            if (exits == null)
            {
                return NotFound();
            }
            var editing = await _postService.MappingToEdittingPostTagsCategoryDTO(exits);
            return View(editing);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(EdittingPostTagsCategoryDTO post)
        {
            if (ModelState.IsValid)
            {
                var editted= await _postService.EditPostAsync(post.PostEdit);
                return RedirectToAction("EditContent", "Post", new { postid = editted.Id });
            }
            return View(post);
        }
        [HttpGet]
        public async Task<IActionResult> EditContent(int postid)
        {
            var result = await _contentsService.GetContentsByPostIdAsync(postid);
            var list = new ContentsEditListDTO()
            {
                ContentsEdits=result
            };
            return View(list);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContent(ContentsEditListDTO contentsEdit)
        {
            if (ModelState.IsValid)
            {
                int postid=0; //Content'siz edit yapılmıyor!!
                foreach (var item in contentsEdit.ContentsEdits)
                {
                    await _contentsService.EditContentsAsync(item);
                    postid = item.PostId;
                }
                if (contentsEdit.AddMoreContent == true)
                {
                    return RedirectToAction("CreateContent", "Post", new { postid = postid});
                }
                else
                {
                    return RedirectToAction("Details", "Post", new { id = postid });
                }
            }
            return View(contentsEdit);
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
        // /categoryadı olsa daha iyi olabilirdi slug
        public async Task<IActionResult> GetPostsByCategory(int id)
        {
            return View(await _postService.GetPostByCategoryIdAsync(id));
        }
    }
}
