using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class MultipleChoiceOptionDTOMapper
    {
        public static MultipleChoiceOption MapFrom(this MultipleChoiceOptionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new MultipleChoiceOption
            {
                Option = dto.Option,
                MultipleChoiceQuestionId = dto.MultipleChoiceQuestionId
            };
        }

        public static MultipleChoiceOptionDTO MapFrom(this MultipleChoiceOption entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new MultipleChoiceOptionDTO
            {
                Id = entity.Id,
                Option = entity.Option,
                MultipleChoiceQuestionId = entity.MultipleChoiceQuestionId,
                Answers = entity.Answers.MapFrom()
            };
        }

        public static ICollection<MultipleChoiceOptionDTO> MapFrom(this ICollection<MultipleChoiceOption> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceOption> MapFrom(this ICollection<MultipleChoiceOptionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
