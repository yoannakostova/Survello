using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using Survello.Web.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survello.Web.Mappers
{
    public static class FormViewModelMapper
    {
        public static FormDTO MapFrom(this FormViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new FormDTO
            {
                Id = viewModel.Id,
                DateOfExpiration = viewModel.DateOfExpiration,
                Title = viewModel.Title,
                Description = viewModel.Description,
                UserId = viewModel.UserId,
                MultipleChoiceQuestions = viewModel.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = viewModel.TextQuestions.MapFrom(),
                DocumentQuestions = viewModel.DocumentQuestions.MapFrom()
            };
        }

        //TODO: Seperate this mapper to two mappers!
        public static FormViewModel MapFrom(this FormDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            List<Question> questions = new List<Question>();

            List<TextQuestionViewModel> textQuestions = new List<TextQuestionViewModel>();
            foreach (var item in dto.TextQuestions)
            {
                textQuestions.Add(item.MapFrom());

                Question question = new Question();
                question.Id = item.Id;
                question.Position = item.QuestionNumber;
                question.QuestionType = "Text";
                questions.Add(question);
            }

            List<MultipleChoiceQuestionViewModel> multipleChoiceQuestions = new List<MultipleChoiceQuestionViewModel>();
            foreach (var item in dto.MultipleChoiceQuestions)
            {
                multipleChoiceQuestions.Add(item.MapFrom());

                Question question = new Question();
                question.Id = item.Id;
                question.Position = item.QuestionNumber;
                question.QuestionType = "Multiple";
                questions.Add(question);
            }

            List<DocumentQuestionViewModel> documentQuestions = new List<DocumentQuestionViewModel>();
            foreach (var item in dto.DocumentQuestions)
            {
                documentQuestions.Add(item.MapFrom());

                Question question = new Question();
                question.Id = item.Id;
                question.Position = item.QuestionNumber;
                question.QuestionType = "Document";
                questions.Add(question);
            }

            questions.OrderBy(q => q.Position);

            var result = new FormViewModel
            {
                Id = dto.Id,
                DateOfExpiration = dto.DateOfExpiration,
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                MultipleChoiceQuestions = multipleChoiceQuestions,
                TextQuestions = textQuestions,
                DocumentQuestions = documentQuestions,
                QuestionNumbers = questions
            };

            return result;
        }

        public static ICollection<FormViewModel> MapFrom(this ICollection<FormDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }

        public static ICollection<FormDTO> MapFrom(this ICollection<FormViewModel> viewModel)
        {
            return viewModel.Select(MapFrom).ToList();
        }
    }
}
