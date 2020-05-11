using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.Provider
{
   public class DateTimeProvider
    {
        public DateTime GetDateTime() => DateTime.UtcNow;
    }
}
