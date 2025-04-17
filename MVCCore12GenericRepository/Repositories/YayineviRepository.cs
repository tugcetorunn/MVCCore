﻿using MVCCore12GenericRepository.Data;
using MVCCore12GenericRepository.Models;

namespace MVCCore12GenericRepository.Repositories
{
    public class YayineviRepository : BaseRepository<Yayinevi>
    {
        public YayineviRepository(SahafDbContext _context) : base(_context)
        {
        }
    }
}
