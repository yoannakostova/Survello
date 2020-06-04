using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class DocumentAnswerViewModelMapper
    {
        public static DocumentAnswerViewModel MapFrom(this DocumentAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentAnswerViewModel
            {
                DocumentQuestionId = dto.DocumentQuestionId,
                Answer = dto.FileName,
                CorelationToken = dto.CorelationToken
            };
        }

        public static ICollection<DocumentAnswerViewModel> MapFrom(this ICollection<DocumentAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
