using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class ContentsServices : IContentsService
    {
        private readonly IContentsRepository contentsRepository;
        private IMapper mapper;
        public ContentsServices(IContentsRepository _contentsRepository, IMapper _mapper)
        {
            contentsRepository = _contentsRepository;
            mapper = _mapper;
        }
        public async Task AddContentsAsync(ContentsAddDTO contents)
        {
            var adding = mapper.Map<ContentsAddDTO, Contents>(contents);
            await contentsRepository.AddAsync(adding);
        }
        public async Task<ContentsListDTO> GetByContentsIdAsync(int id)
        {
            var result = await contentsRepository.GetByIdAsync(id);
            if (result == null)
            {
                return null;
            }
            return mapper.Map<Contents, ContentsListDTO>(result);
        }
        public async Task<List<ContentsListDTO>> GetContentsListAsync()
        {
            var list = await contentsRepository.GetAllAsync();
            return mapper.Map<List<ContentsListDTO>>(list);
        }
        public async Task EditContentsAsync(ContentsEditDTO contents)
        {
            var editing = mapper.Map<ContentsEditDTO, Contents>(contents);
            await contentsRepository.UpdateAsync(editing);
        }
        public async Task RemoveContentsAsync(ContentsDeleteDTO contents)
        {
            var removing = mapper.Map<ContentsDeleteDTO, Contents>(contents);
            await contentsRepository.DeleteAsync(removing.Id);
        }
    }
}
