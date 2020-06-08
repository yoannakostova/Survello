using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Services.DTOMappers
{
    public static class ListFormsDTOMapper
    {
        public static ListFormsDTO MapToListFormsDTO(this Form entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new ListFormsDTO
            {
                Id = entity.Id,
                CreatedOn = entity.CreatedOn,
                Title = entity.Title,
                UserId = entity.UserId,
                NumberOfFilledForms = entity.NumberOfFilledForms,
            };
        }

        public static ICollection<ListFormsDTO> MapToListFormsDTO(this ICollection<Form> entities)
        {
            return entities.Select(MapToListFormsDTO).ToList();
        }
    }
}
