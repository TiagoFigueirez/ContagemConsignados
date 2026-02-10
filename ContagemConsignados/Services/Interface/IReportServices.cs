using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContagemConsignados.Services.Interface
{
    public interface IReportServices
    {
        byte[] GerarPdf(string html);
    }
}
