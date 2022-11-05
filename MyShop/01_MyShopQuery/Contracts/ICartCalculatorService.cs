﻿using System.Collections.Generic;
using InventoryManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Infrastructure.EFCore;

namespace _01_MyShopQuery.Contracts
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}