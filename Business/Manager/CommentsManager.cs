﻿using Business.Services;
using Data.Services;
using DTO.DTOS.CommentDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class CommentcManager : ICommentService
    {
        private readonly ICommentDAL _dal;
        public CommentcManager(ICommentDAL dal)
        {
            _dal = dal;
        }

        public Task<IQueryable<Comments>> CommentListByProduct(Guid ProductId)
        {
           return _dal.CommentListByProduct(ProductId); 
        }

        public async Task Create(Comments entity)
        {
           await  _dal.Create(entity);
        }

        public async Task Delete(Comments entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Comments>> GetAll()
        {
            return await _dal.GetAll();
        }

        public Comments GetById(int id)
        {
            return _dal.GetById(id);
        }
        public Comments GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public async Task<CommentRatedPercentDTO> GetCommentRatedPercent(Guid ProductId)
        {
            return await _dal.GetCommentRatedPercent(ProductId);
        }

        public async Task Update(Comments entity)
        {
            await _dal.Update(entity);
        }
    }
}
