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
                MultipleChoiceOptionId = entity.MultipleChoiceOptionId,
                CorelationToken = entity.CorelationToken
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