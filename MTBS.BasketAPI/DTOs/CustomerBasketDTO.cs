﻿using MTBS.BasketAPI.Models;

namespace MTBS.BasketAPI.DTOs
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
