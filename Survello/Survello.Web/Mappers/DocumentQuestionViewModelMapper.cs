using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class DocumentQuestionViewModelMapper
    {
        public static DocumentQuestionDTO MapFrom(this DocumentQuestionViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }
            var fileSize = int.Parse(viewModel.FileSize.Substring(0, viewModel.FileSize.Length - 2));

            return new DocumentQuestionDTO
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                FileNumberLimit = viewModel.FileNumberLimit,
                FileSize = fileSize,
                IsRequired = viewModel.IsRequired,
                QuestionNumber = viewModel.QuestionNumber,
                Files = viewModel.Files
            };
        }
        public static ICollection<DocumentQuestionDTO> MapFrom(this ICollection<DocumentQuestionViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }
        public static DocumentQuestionViewModel MapFrom(this DocumentQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }


            return new DocumentQuestionViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                FileNumberLimit = dto.FileNumberLimit,
                FileSize = dto.FileSize.ToString(),
                IsRequired = dto.IsRequired,
                QuestionNumber = dto.QuestionNumber,
                FilePath = dto.FilePath
            };
        }
        public static ICollection<DocumentQuestionViewModel> MapFrom(this ICollection<DocumentQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
