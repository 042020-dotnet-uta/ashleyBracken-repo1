using System;
using System.Collections.Generic;
using System.Text;

namespace SleepingSelkieBusinessLogic
{
  public  class IdentifierService
    {
        public Guid guid { get; } = Guid.NewGuid();
    }
    public class Singleton : IdentifierService
    { }
    public class Scoped : IdentifierService
    { }
    public class Transient : IdentifierService
    { }
}
