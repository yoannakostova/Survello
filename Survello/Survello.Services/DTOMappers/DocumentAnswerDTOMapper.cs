using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Services.DTOMappers
{
    public static class DocumentAnswerDTOMapper
    {
        public static DocumentAnswerDTO MapFrom(this DocumentAnswer entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentAnswerDTO
            {
                FileName = entity.FileName,
                DocumentQuestionId = entity.DocumentQuestionId,
                CorelationToken = entity.CorelationToken
            };
        }

        public static ICollection<DocumentAnswerDTO> MapFrom(this ICollection<DocumentAnswer> entities)
        {
            return entities.Select(MapFrom).ToList();
        }
    }
}
