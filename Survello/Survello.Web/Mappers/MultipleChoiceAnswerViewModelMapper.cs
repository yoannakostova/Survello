using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class MultipleChoiceAnswerViewModelMapper
    {
        public static MultipleChoiceAnswerViewModel MapFrom(this MultipleChoiceAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceAnswerViewModel
            {
                Answer = dto.Answer,
                CorelationToken = dto.CorelationToken,
                MultipleChoiceOptionId = dto.MultipleChoiceOptionId
            };
        }

        public static ICollection<MultipleChoiceAnswerViewModel> MapFrom(this ICollection<MultipleChoiceAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
