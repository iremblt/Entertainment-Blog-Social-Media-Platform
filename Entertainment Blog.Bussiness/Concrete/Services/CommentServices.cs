using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.CommentDTO;
using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class CommentServices:ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private IMapper _mapper;
        public CommentServices(ICommentRepository commentRepository,IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentListDTO>> GetComments()
        {
            var comments= await _commentRepository.CommentsListAsync();
            return _mapper.Map<List<CommentListDTO>>(comments);
        }
        public async Task AddComment(CommentAddDTO comment)
        {
            var mapcomment = _mapper.Map<CommentAddDTO,Comment>(comment);
            await _commentRepository.AddAsync(mapcomment);
        }
    }
}
