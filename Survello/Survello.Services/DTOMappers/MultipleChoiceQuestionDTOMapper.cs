using Survello.Database.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class MultipleChoiceQuestionDTOMapper
    {
        public static MultipleChoiceQuestion MapFrom(this MultipleChoiceQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceQuestion
            {
                Id = dto.Id,
                Description = dto.Description,
                IsRequired = dto.IsRequired,
                Options = dto.Options.MapFrom(),
                Answers = dto.Answers.MapFrom(),
                FormId = dto.FormId
            };
        }

        public static MultipleChoiceQuestionDTO MapFrom(this MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                IsRequired = entity.IsRequired,
                Options = entity.Options.MapFrom(),
                Answers = entity.Answers.MapFrom(),
                FormId = entity.FormId,
                FormName = entity.Form.Title
            };
        }

        public static ICollection<MultipleChoiceQuestionDTO> MapFrom(this ICollection<MultipleChoiceQuestion> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceQuestion> MapFrom(this ICollection<MultipleChoiceQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
