using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class DocumentQuestionDTOMapper
    {
        public static DocumentQuestionDTO MapFrom(this DocumentQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                FileNumberLimit = entity.FileNumberLimit,
                FileSize = entity.FileSize,
                IsRequired = entity.IsRequired,
                QuestionNumber = entity.QuestionNumber,
            };
        }
        public static ICollection<DocumentQuestionDTO> MapFrom(this ICollection<DocumentQuestion> entities)
        {
            return entities.Select(MapFrom).ToList();
        }
        public static DocumentQuestion MapFrom(this DocumentQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentQuestion
            {
                Id = dto.Id,
                Description = dto.Description,
                FileNumberLimit = dto.FileNumberLimit,
                FileSize = dto.FileSize,
                IsRequired = dto.IsRequired,
                QuestionNumber = dto.QuestionNumber
            };
        }
        public static ICollection<DocumentQuestion> MapFrom(this ICollection<DocumentQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
