using FluentValidation;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.BusinessLogicLayer.Validations
{
    internal class ImageValidation:AbstractValidator<Image>
    {
        IimageDAL ıimageDAL;
        public ImageValidation(IimageDAL dAL)
        {
            RuleFor(c => c.GameID).NotNull().WithMessage("Oyun Id Alanı Boş Geçilemez!");
            RuleFor(c => c.ImageURL).NotNull().WithMessage("Fotograf Url Alanı Boş Geçilemez!");

            ıimageDAL = dAL;
        }
    }
}
