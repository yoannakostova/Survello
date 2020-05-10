﻿using Survello.Database.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class TextQuestionDTOMapper
    {
        public static TextQuestion MapFrom(this TextQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new TextQuestion
            {
                Id = dto.Id,
                Description = dto.Description,
                IsLongAnswer = dto.IsLongAnswer,
                IsRequired = dto.IsRequired,
                FormId = dto.FormId,
                Answers = dto.Answers.MapFrom()
            };
        }

        public static TextQuestionDTO MapFrom(this TextQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new TextQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                IsLongAnswer = entity.IsLongAnswer,
                IsRequired = entity.IsRequired,
                Answers = entity.Answers.MapFrom(),
                FormId = entity.FormId,
                FormTitle = entity.Form.Title
            };
        }

        public static ICollection<TextQuestionDTO> MapFrom(this ICollection<TextQuestion> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<TextQuestion> MapFrom(this ICollection<TextQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
