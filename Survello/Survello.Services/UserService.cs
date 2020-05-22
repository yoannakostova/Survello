using Survello.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services
{
   public class UserService
    {
        private readonly SurvelloContext context;

        public UserService(SurvelloContext context)
        {
            this.context = context;
        }

    }
}
