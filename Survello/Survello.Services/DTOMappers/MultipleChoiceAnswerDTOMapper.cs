﻿using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survello.Services.DTOMappers
{
    public static class MultipleChoiceAnswerDTOMapper
    {
        public static MultipleChoiceAnswer MapFrom(this MultipleChoiceAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new MultipleChoiceAnswer
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                MultipleChoiceOptionId = dto.MultipleChoiceOptionId,
                CorelationToken = dto.CorelationToken
            };
        }

        public static MultipleChoiceAnswerDTO MapFrom(this MultipleChoiceAnswer entity)
        {
            if (entity == null)
            {
                throw new Exception(ExceptionMessages.EntityNotFound);
            }

            return new MultipleChoiceAnswerDTO
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                CorelationToken = entity.CorelationToken,
                MultipleChoiceOptionId = entity.MultipleChoiceOptionId,
            };
        }

        public static ICollection<MultipleChoiceAnswerDTO> MapFrom(this ICollection<MultipleChoiceAnswer> entities)
        {
            return entities.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceAnswer> MapFrom(this ICollection<MultipleChoiceAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}