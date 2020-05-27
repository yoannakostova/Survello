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

        public static DocumentAnswer MapFrom(this DocumentAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentAnswer
            {
                Id = dto.Id,
                DocumentQuestionId = dto.DocumentQuestionId,
                CorelationToken = dto.CorelationToken,
                IsDeleted = dto.IsDeleted,
                FileName = dto.FileName
            };
        }
        public static ICollection<DocumentAnswer> MapFrom(this ICollection<DocumentAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
        public static ICollection<DocumentAnswerDTO> MapFrom(this ICollection<DocumentAnswer> entities)
        {
            return entities.Select(MapFrom).ToList();
        }
    }
}
