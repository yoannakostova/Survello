using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.Provider.Contract
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTime();
    }
}
