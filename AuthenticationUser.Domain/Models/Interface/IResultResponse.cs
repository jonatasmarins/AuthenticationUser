using Flunt.Notifications;
using System.Collections.Generic;

namespace AuthenticationUser.Domain.Models.Interface
{
    public interface IResultResponse
    {
        bool Success { get; }
        IList<KeyValuePair<string, string>> ErrorMessages { get; set; }
    }
}
