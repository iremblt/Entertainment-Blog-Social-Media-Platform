﻿using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;

namespace Entertainment_Blog.DTO.DTOs.PostTagDTO
{
    public class PostTagListDTO
    {
        public PostListDTO Post { get; set; }
        public int PostId { get; set; }
        public TagListDTO Tag { get; set; }
        public int TagId { get; set; }
    }
}
