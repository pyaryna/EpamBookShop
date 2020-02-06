using AutoMapper;
using BookShop.BLL.DTOs;
using BookShop.BLL.Interfaces;
using BookShop.DAL;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL.Services
{
    public class CartService: ICartService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartDto>> GetCartForUserAsync(string id)
        {
            IEnumerable<Cart> carts = await _unitOfWork.Carts.GetUserCartsAsync(id);

            return carts.Select(_mapper.Map<Cart, CartDto>)
                .ToArray();
        }

        public async Task AddCartAsync(AddCartDto addCart)
        {
            _unitOfWork.Carts.Add(_mapper.Map<AddCartDto, Cart>(addCart));

            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveCartByIdAsync(int id)
        {
            var cart = await _unitOfWork.Carts.FindAsync(id);

            _unitOfWork.Carts.Remove(cart);

            await _unitOfWork.CommitAsync();
        }
    }
}
