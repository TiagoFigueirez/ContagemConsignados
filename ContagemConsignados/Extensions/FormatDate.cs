using System.Globalization;
using System.Text;

namespace ContagemConsignados.Extensions
{
    public static class FormatDate
    {
        public static bool FomartDate(this string value,out DateTime result)
        {
            return DateTime.TryParseExact(
                value,
                "ddMMyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out result
                );
        }
    }
}
