using Survello.Services.Provider.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.Provider
{
   public class DateTimeProvider :IDateTimeProvider
    {
        public DateTime GetDateTime() => DateTime.UtcNow;
    }
}
