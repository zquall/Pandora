using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Extensions.Types
{
    public static class DateTimeExtension
    {
        public static int ToYearMonthDay(this DateTime value)
        {
            return value.Year*10000 + value.Month*100 + value.Day;
        }
    }
}
