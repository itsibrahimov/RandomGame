using FluentValidation;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.BusinessLogicLayer.Validations
{
    internal class CategoryValidation:AbstractValidator<Category>
    {
        ICategoryDAL categoryDAL;
        public CategoryValidation(ICategoryDAL dAL)
        {
            RuleFor(s => s.CategoryName).Length(5, 30).WithMessage("Kategori İsmi 5-30 Karakter arasında olmalı!");
            RuleFor(s => s.CategoryName).NotNull().WithMessage("Kategori ismi boş geçilemez!");
            categoryDAL = dAL;
        }
    }
}
