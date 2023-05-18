using FluentValidation;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RandomGame.BusinessLogicLayer.Validations
{
    internal class GameCategoryValidation:AbstractValidator<GameCategory>
    {
        IGameCategoryDAL dal;
        public GameCategoryValidation(IGameCategoryDAL gameCategoryDAL)
        {
            RuleFor(x => x.CategoryID).NotNull().WithMessage("Kategori Id Alanı Boş Geçilemez!");
            RuleFor(x => x.GameID).NotNull().WithMessage("Oyun Id Alanı Boş Geçilemez!");


            dal = gameCategoryDAL;   
        }
    }
}
