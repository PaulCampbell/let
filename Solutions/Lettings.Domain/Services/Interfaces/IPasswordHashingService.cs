using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lettings.Domain.Services.Interfaces
{
    public interface IPasswordHashingService
    {
        string ComputeHash(string plainText, byte[] saltBytes);
        bool VerifyHash(string plainText, string hashValue);
    }
}
