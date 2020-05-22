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
        public static DocumentAnswerDTO MapFrom(this DocumentAnswerViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentAnswerDTO
            {
                Id = viewModel.Id,
                FileName = viewModel.FileName,
                DocumentQuestionId = viewModel.DocumentQuestionId,
                CorelationToken = viewModel.CorelationToken
            };
        }
        public static ICollection<DocumentAnswerDTO> MapFrom(this ICollection<DocumentAnswerViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }
        public static DocumentAnswerViewModel MapFrom(this DocumentAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new DocumentAnswerViewModel
            {
                Id = dto.Id,
                FileName = dto.FileName,
                DocumentQuestionId = dto.DocumentQuestionId,
                CorelationToken = dto.CorelationToken
            };
        }
        public static ICollection<DocumentAnswerViewModel> MapFrom(this ICollection<DocumentAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
