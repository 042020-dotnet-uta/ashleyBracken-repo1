using System;
using System.Collections.Generic;
using System.Text;

namespace SleepingSelkieBusinessLogic.IRepositories
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        (bool Verfied, bool NeedsUpgrade) Check(string has, string password);
    }
}
