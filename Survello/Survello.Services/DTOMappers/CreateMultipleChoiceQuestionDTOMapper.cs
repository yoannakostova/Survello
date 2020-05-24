using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class CreateMultipleChoiceQuestionDTOMapper
    {
        public static MultipleChoiceQuestion MapFrom(this CreateMultipleChoiceQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new MultipleChoiceQuestion
            {
                //Id = dto.Id, //no need since we set it as [Key]
                Description = dto.Description,
                IsRequired = dto.IsRequired,
                IsMultipleAnswer = dto.IsMultipleAnswer,
                Options = dto.Options.MapFrom(),
                FormId = dto.FormId,
                QuestionNumber = dto.QuestionNumber
            };
        }

        public static CreateMultipleChoiceQuestionDTO MapFrom(this MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new CreateMultipleChoiceQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                IsRequired = entity.IsRequired,
                IsMultipleAnswer = entity.IsMultipleAnswer,
                Options = entity.Options.MapFrom(),
                FormId = entity.FormId,
                QuestionNumber = entity.QuestionNumber
            };
        }

        public static ICollection<CreateMultipleChoiceQuestionDTO> MapFrom(this ICollection<MultipleChoiceQuestion> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceQuestion> MapFrom(this ICollection<CreateMultipleChoiceQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
