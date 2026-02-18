using System.Text;

namespace ContagemConsignados.Extensions
{
    public static class FormatDate
    {
        public static DateTime FomartDate(this string value)
        {
            var stringFormat = value.Insert(2, "/").Insert(3, "/20");
            var dateFormated = Convert.ToDateTime(stringFormat);

            return dateFormated;
        }
    }
}
