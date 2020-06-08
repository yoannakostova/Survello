using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Survello.Web.Common
{
    public class Parser
    {
        public bool MapMultipleQuestionsWithOptions(FormViewModel model)
        {
            try
            {
                foreach (var question in model.MultipleChoiceQuestions)
                {
                    foreach (var desc in question.OptionsDescriptions)
                    {
                        var optionModel = new MultipleChoiceOptionViewModel();
                        optionModel.OptionDescription = desc;
                        question.Options.Add(optionModel);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }           
        }
    }
}
