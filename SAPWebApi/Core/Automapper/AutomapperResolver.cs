
using AutoMapper;

namespace Core.Automapper
{
    public class AutomapperResolver
    {
        public class SapBooleanResolver : ValueResolver<bool, string>
        {
            protected override string ResolveCore(bool source)
            {
                return source ? "tYES" : "tNO";
            }
        }

    }
}
