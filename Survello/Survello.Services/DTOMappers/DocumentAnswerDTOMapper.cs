using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class DocumentAnswerDTOMapper
    {
        public static DocumentAnswer MapFrom(this DocumentAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentAnswer
            {
                Id = dto.Id,
                FileName = dto.FileName,
                DocumentQuestionId = dto.DocumentQuestionId,
                CorelationToken = dto.CorelationToken
            };
        }
        public static ICollection<DocumentAnswer> MapFrom(this ICollection<DocumentAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
        public static DocumentAnswerDTO MapFrom(this DocumentAnswer entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentAnswerDTO
            {
                Id = entity.Id,
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
