using NToastNotify;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Common
{
    public class DataValidator
    {
        public bool ValidateAnswer(FormViewModel form)
        {
            foreach (var tq in form.TextQuestions)
            {
                if (tq.IsRequired == true && tq.Description == string.Empty)
                {
                    return false;
                }
            }
            foreach (var mcq in form.MultipleChoiceQuestions)
            {
                if (mcq.IsRequired && mcq.IsMultipleAnswer == false)
                {

                    if (mcq.RadioButtonAnswer == null)
                    {
                        return false;
                    }
                }
                if (mcq.IsRequired && mcq.IsMultipleAnswer)
                {
                    var hasAnswer = false;

                    foreach (var option in mcq.Options)
                    {
                        if (option.Answer != null)
                        {
                            hasAnswer = true;
                        }
                    }

                    if (!hasAnswer)
                    {
                        return false;
                    }
                }
            }

            foreach (var dq in form.DocumentQuestions)
            {
                if (dq.IsRequired == true)
                {
                    if (dq.Files.Count == 0)
                    {
                        return false;
                    }
                }

                if (dq.Files == null && dq.IsRequired == false)
                {
                    continue;
                }

                var fileSize = long.Parse(dq.FileSize) * 1024 * 1024;

                foreach (var file in dq.Files)
                {
                    if (file != null)
                    {
                        if (fileSize < file.Length)
                        {
                            return false;
                        }
                        if (dq.FileNumberLimit < dq.Files.Count)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
