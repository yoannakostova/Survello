using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Services.DTOMappers
{
    public static class FormDTOMapper
    {
        public static Form MapFrom(this FormDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new Form
            {
                Id = dto.Id,
                LastModifiedOn = dto.LastModifiedOn,
                DateOfExpiration = dto.DateOfExpiration,
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                NumberOfFilledForms = dto.NumberOfFilledForms,
                MultipleChoiceQuestions = dto.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = dto.TextQuestions.MapFrom(),
                DocumentQuestions = dto.DocumentQuestions.MapFrom()
            };
        }

        public static FormDTO MapFrom(this Form entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new FormDTO
            {
                Id = entity.Id,
                LastModifiedOn = entity.LastModifiedOn,
                DateOfExpiration = entity.DateOfExpiration,
                Title = entity.Title,
                Description = entity.Description,
                UserId = entity.UserId,
                NumberOfFilledForms = entity.NumberOfFilledForms,
                MultipleChoiceQuestions = entity.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = entity.TextQuestions.MapFrom(),
                DocumentQuestions = entity.DocumentQuestions.MapFrom()
            };
        }

        public static ICollection<FormDTO> MapFrom(this ICollection<Form> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<Form> MapFrom(this ICollection<FormDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
