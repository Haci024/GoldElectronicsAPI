using AutoMapper;
using DTO.DTOS.CommentDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class CommentMapper:Profile
    {
        public CommentMapper()
        {
            CreateMap<Comments, NewCommentDTO>();
            CreateMap<NewCommentDTO, Comments>();

            CreateMap<Comments, ReplyCommentDTO>();
            CreateMap<ReplyCommentDTO, Comments>();

            CreateMap<Comments, UpdateCommentDTO>();
            CreateMap<UpdateCommentDTO, Comments>();

            CreateMap<Comments, DeleteCommentDTO>();
            CreateMap<DeleteCommentDTO, Comments>();

            CreateMap<Comments, CommentListDTO>();
            CreateMap<CommentListDTO, Comments>();
        }
    }
}
