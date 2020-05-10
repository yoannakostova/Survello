using Survello.Database.Entites;
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
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceOption
            {
                Id = dto.Id,
                Option = dto.Option,
                MultipleChouceQuestionId = dto.MultipleChouceQuestionId
            };
        }

        public static MultipleChoiceOptionDTO MapFrom(this MultipleChoiceOption entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceOptionDTO
            {
                Id = entity.Id,
                  Option = entity.Option,
                   MultipleChouceQuestionId = entity.MultipleChouceQuestionId
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
