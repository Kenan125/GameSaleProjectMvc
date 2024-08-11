﻿using GameSaleProject_Entity.Entities;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IGameService 
    {
        IEnumerable<Game> GetAllWithImages();

    }
}
