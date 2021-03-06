﻿using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Services.DTOMappers
{
    public static class MultipleChoiceQuestionDTOMapper
    {
        public static MultipleChoiceQuestion MapFrom(this MultipleChoiceQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new MultipleChoiceQuestion
            {
                Description = dto.Description,
                IsRequired = dto.IsRequired,
                IsMultipleAnswer = dto.IsMultipleAnswer,
                Options = dto.Options.MapFrom(),
                QuestionNumber = dto.QuestionNumber
            };
        }

        public static MultipleChoiceQuestionDTO MapFrom(this MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            var answer = new List<string>();
            foreach (var item in entity.Answers)
            {
                answer.Add(item.Answer);
            }

            return new MultipleChoiceQuestionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                IsRequired = entity.IsRequired,
                IsMultipleAnswer = entity.IsMultipleAnswer,
                Options = entity.Options.MapFrom(),
                QuestionNumber = entity.QuestionNumber,
                Answers = answer
            };
        }

        public static ICollection<MultipleChoiceQuestionDTO> MapFrom(this ICollection<MultipleChoiceQuestion> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceQuestion> MapFrom(this ICollection<MultipleChoiceQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
