using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class CreateDocumentQuestionDTOMapper
    {
        public static CreateDocumentQuestionDTO MapFrom(this DocumentQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new CreateDocumentQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                FileNumberLimit = entity.FileNumberLimit,
                FileSize = entity.FileSize,
                IsRequired = entity.IsRequired,
                QuestionNumber = entity.QuestionNumber
            };
        }
        public static ICollection<CreateDocumentQuestionDTO> MapFrom(this ICollection<DocumentQuestion> entities)
        {
            return entities.Select(MapFrom).ToList();
        }
        public static DocumentQuestion MapFrom(this CreateDocumentQuestionDTO dto)
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
        public static ICollection<DocumentQuestion> MapFrom(this ICollection<CreateDocumentQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
