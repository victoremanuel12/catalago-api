﻿using WebAPIMocoratti.Context;
using WebAPIMocoratti.Repository.Interfaces;

namespace WebAPIMocoratti.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private  ProdutoRepository _produtoRepository;
        private  CategoriaRepository _categoriaRepository;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get 
            {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context); 
            }
        }

        public ICategoriaRepository CategoriaRepository
        {

            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }
        public async Task Comit()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose() 
        { 
            _context.Dispose();
        }
    }
}
