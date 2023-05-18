using FluentValidation;
using FluentValidation.Results;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.BusinessLogicLayer.Validations
{
    internal class GameValidation:AbstractValidator<Game>
    {
        IGameDAL dAL;
        public GameValidation(IGameDAL gameDAL)
        {
            RuleFor(x => x.GameName).MinimumLength(1).MaximumLength(50).WithMessage("Oyun İsmi 1-50 Karakter Arasında Olmalı!");
            RuleFor(x => x.GameName).NotNull().WithMessage("Oyun İsmi Alanı Boş Geçilemez!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Açıklama alanı minimum 50 karakter olmalı!");
            RuleFor(x => x.Description).NotNull().WithMessage("Açıklama Alanı Boş Geçilemez!");
            RuleFor(x => x.Price).NotNull().WithMessage("Fiyat Alanı Boş Geçilemez!");
            RuleFor(x => x.Stock).NotNull().WithMessage("Stok Alanı Boş Geçilemez!");
            dAL = gameDAL;
        }
    }
}
