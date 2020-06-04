using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Web.Mappers
{
    public static class TextAnswerViewModelMapper
    {
        public static TextAnswerViewModel MapFrom(this TextAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new TextAnswerViewModel
            {
                TextQuestionId = dto.TextQuestionId,
                CorelationToken = dto.CorelationToken,
                Answer = dto.Answer
            };
        }

        public static ICollection<TextAnswerViewModel> MapFrom(this ICollection<TextAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
