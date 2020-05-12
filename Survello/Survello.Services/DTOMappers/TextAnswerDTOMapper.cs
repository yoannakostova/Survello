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
        public static TextAnswer MapFrom(this TextAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new TextAnswer
            {
                Id = dto.Id,
                Answer = dto.Answer,
                TextQuestionId = dto.TextQuestionId,
                 CorelationToken = dto.CorelationToken,
            };
        }

        public static TextAnswerDTO MapFrom(this TextAnswer entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new TextAnswerDTO
            {
                Id = entity.Id,
                Answer = entity.Answer,
                TextQuestionId = entity.TextQuestionId,
                TextQuestionDescription = entity.TextQuestion.Description,
                 CorelationToken = entity.CorelationToken
                 
            };
        }

        public static ICollection<TextAnswerDTO> MapFrom(this ICollection<TextAnswer> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<TextAnswer> MapFrom(this ICollection<TextAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
