using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class AnswerFormViewModelMapper
    {
        public static AnswerFormViewModel MapToAnswerFormViewModel(this FormDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            var form = new AnswerFormViewModel();


            foreach (var question in dto.DocumentQuestions.MapFrom())
            {
                form.QuestionNumbers.Add(question.QuestionNumber, question);
            }

            foreach (var question in dto.MultipleChoiceQuestions.MapFrom())
            {
                form.QuestionNumbers.Add(question.QuestionNumber, question);
            }

            foreach (var question in dto.TextQuestions.MapFrom())
            {
                form.QuestionNumbers.Add(question.QuestionNumber, question);
            }


            form.Id = dto.Id;
            form.Title = dto.Title;
            form.Description = dto.Description;
            form.TextQuestions = dto.TextQuestions.MapFrom();

            return form;
        }
    }
}

