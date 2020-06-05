using Survello.Services.Provider.Contract;
using System;

namespace Survello.Services.Provider
{
   public class DateTimeProvider :IDateTimeProvider
    {
        public DateTime GetDateTime() => DateTime.UtcNow;
    }
}
