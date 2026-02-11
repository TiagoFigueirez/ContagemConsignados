namespace ContagemConsignados.Services.Interface
{
    public interface IReportServices
    {
        byte[] GerarPdf(string html);
    }
}
