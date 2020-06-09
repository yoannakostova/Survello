using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Web.Mappers
{
    public static class ListFormsViewModelMapper
    {
        public static ListFormsViewModel MapToListFormsViewModel(this ListFormsDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new ListFormsViewModel
            {
                Id = dto.Id,
                CreatedOn = dto.CreatedOn,
                Title = dto.Title,
                NumberOfFilledForms = dto.NumberOfFilledForms,
            };
        }

        public static ICollection<ListFormsViewModel> MapToListFormsViewModel(this ICollection<ListFormsDTO> dtos)
        {
            return dtos.Select(MapToListFormsViewModel).ToList();
        }
    }
}

