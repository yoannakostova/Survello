﻿using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Services.DTOMappers
{
    public static class TextQuestionDTOMapper
    {
        public static TextQuestion MapFrom(this TextQuestionDTO dto)
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
                QuestionNumber = dto.QuestionNumber,
            };
        }

        public static TextQuestionDTO MapFrom(this TextQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            var answer = string.Empty;

            if (entity.Answers.Count > 0)
            {
                foreach (var item in entity.Answers)
                {
                    answer = item.Answer;
                    break;
                }
            }

            return new TextQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                IsLongAnswer = entity.IsLongAnswer,
                IsRequired = entity.IsRequired,
                QuestionNumber = entity.QuestionNumber,
                Answer = answer
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
