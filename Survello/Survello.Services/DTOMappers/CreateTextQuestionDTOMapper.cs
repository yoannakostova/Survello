﻿using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class CreateTextQuestionDTOMapper
    {
        public static TextQuestion MapFrom(this CreateTextQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new TextQuestion
            {
                Id = dto.Id,
                Description = dto.Description,
                IsLongAnswer = dto.IsLongAnswer,
                IsRequired = dto.IsRequired,
                FormId = dto.FormId, 
                QuestionNumber = dto.QuestionNumber
            };
        }

        public static CreateTextQuestionDTO MapFrom(this TextQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new CreateTextQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                IsLongAnswer = entity.IsLongAnswer,
                IsRequired = entity.IsRequired,
                FormId = entity.FormId,
                QuestionNumber = entity.QuestionNumber
            };
        }

        public static ICollection<CreateTextQuestionDTO> MapFrom(this ICollection<TextQuestion> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<TextQuestion> MapFrom(this ICollection<CreateTextQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}