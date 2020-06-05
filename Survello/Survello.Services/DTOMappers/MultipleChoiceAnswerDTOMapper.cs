using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Services.DTOMappers
{
    public static class MultipleChoiceAnswerDTOMapper
    {
        public static MultipleChoiceAnswerDTO MapFrom(this MultipleChoiceAnswer entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new MultipleChoiceAnswerDTO
            {
                CorelationToken = entity.CorelationToken,
                MultipleChoiceOptionId = entity.MultipleChoiceOptionId,
                Answer = entity.Answer
            };
        }

        public static ICollection<MultipleChoiceAnswerDTO> MapFrom(this ICollection<MultipleChoiceAnswer> entities)
        {
            return entities.Select(MapFrom).ToList();
        }
    }
}
