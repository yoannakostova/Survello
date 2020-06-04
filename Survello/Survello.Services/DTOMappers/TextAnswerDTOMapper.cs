using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class TextAnswerDTOMapper
    {
        public static TextAnswerDTO MapFrom(this TextAnswer entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new TextAnswerDTO
            {
                CorelationToken = entity.CorelationToken,
                Answer = entity.Answer,
                TextQuestionId = entity.TextQuestionId
            };
        }

        public static ICollection<TextAnswerDTO> MapFrom(this ICollection<TextAnswer> entities)
        {
            return entities.Select(MapFrom).ToList();
        }
    }
}
