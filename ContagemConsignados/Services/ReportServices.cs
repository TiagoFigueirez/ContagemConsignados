using ContagemConsignados.Services.Interface;
using System.Text;
using System.IO;
using iText.Html2pdf;

namespace ContagemConsignados.Services
{
    public class ReportServices : IReportServices
    {
        public byte[] GerarPdf(string html)
        {
            var reportFormat = ReportBuilder();
            using (var memoryStream = new MemoryStream())
            {
                HtmlConverter.ConvertToPdf(reportFormat, memoryStream);
                    return memoryStream.ToArray();
            }
        }

        private string ReportBuilder()
        {
            StringBuilder sb = new StringBuilder();
            string LogoReport = "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JrZk6eRAgSPy0XOAq4AzUU9lYzyM80MTOPvEjB/GnCzjV1dSwZWLDn1ppsITJK+X3SjD89aLAm1qhYrOztf3kcMSY/jx/Wm/ZbAlj5UJMw+bgfPUzwK9v5LMcYxnvUUdjFG8TqWzGDjJ65pWQcz7kY03TO1vBUsMNnbZMKQx84JUDr6ULYwqGADfM+889/8ACkNjGY1Tc21X3r7GiyG5Se7JZYoLkGOVI5QOoYZxUA0mwBz9ljqdIFSd5QTl+o7VLRZCUmtmNREjQJGioo6BRgU6iimIKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAFLSCloAKKKKACiiigAooooASiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigBaKKKACkpaSgAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACilooASilooASilooASilooASilooASilooASilooASilooASilooASilooASilooASilooASilooASilooAQUtFFABRRRQAUUUUAFFFFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFACUUtFABRRRQAUlLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQAlFLRQB/9k=";

            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style>");
            sb.AppendLine("@page { size: A4 landscape; }");
            sb.AppendLine("@media print { .naoQuebrar { page-break-inside: avoid; } }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body style='font-family: Arial;'>");


            // ================= LOGO =================
            sb.AppendLine("<div style='display:flex; flex-direction:column; justify-content:center; align-items:center;'>");
            sb.AppendLine($"<img src=data:[tipo]/[formato];base64,'{LogoReport}' style='width:700px; height:auto;' />");
            sb.AppendLine("</div>");


            // ================= CABEÇALHO =================
            sb.AppendLine("<div style='font-size:15px; display:flex; justify-content:space-around; align-items:center;'>");

            sb.AppendLine("<div></div>");

            sb.AppendLine("<div style='display:flex; flex-direction:column; align-items:center; font-weight:bold;'>");
            sb.AppendLine("<div>POP SGQ 28 - VERSÃO n001</div>");
            sb.AppendLine("<div>ANEXO 03</div>");
            sb.AppendLine("<div>CONTROLE DE CONSIGNADOS</div>");
            sb.AppendLine("</div>");

            sb.AppendLine($"<div><h3>{DateTime.UtcNow.ToString("dd-MM-yyyy")}</h3></div>");
            sb.AppendLine("</div>");

            sb.AppendLine("<br/>");


            // ================= CLIENTE =================
            sb.AppendLine("<div style='font-size:15px; font-weight:bold; display:flex; align-items:center; gap:60px;'>");

            sb.AppendLine($"<div>CLIENTE:<span style='margin-left:30px;'>HOSPITAL AQUI</span></div>");

            sb.AppendLine("<div style='display:flex; gap:20px;'>");
            sb.AppendLine("<div style='display:flex; flex-direction:column; align-items:center;'>");
            sb.AppendLine("<div>TOTAL</div>");
            sb.AppendLine("<div>CONSIGNADO</div>");
            sb.AppendLine("</div>");
            sb.AppendLine($"<div style='margin-left:30px;'>TOTAL DE ITEMS AQUI</div>");
            sb.AppendLine("</div>");

            sb.AppendLine("<div>ITENS CONSIGNADOS</div>");
            sb.AppendLine("</div>");


            // ================= TABELA =================
            sb.AppendLine("<table style='width:100%; border:1px solid #000; border-collapse:collapse; font-size:15px;'>");

            sb.AppendLine("<thead style='background-color:#d9d9d9; font-weight:bold;'>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='border:1px solid #000; padding:8px;'>PRODUTO</th>");
            sb.AppendLine("<th style='border:1px solid #000;'>LOTE</th>");
            sb.AppendLine("<th style='border:1px solid #000;'>QUANTIDADE</th>");
            sb.AppendLine("<th style='border:1px solid #000;'>VALIDADE</th>");
            sb.AppendLine("<th style='border:1px solid #000;'>CONFERÊNCIA</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");

            sb.AppendLine("<tbody>");

            //foreach (var item in itens)
            //{
            //    var meses = (item.Validade - DateTime.Today).TotalDays / 30;
            //    bool vencendo = meses <= 3;

            //    string cor = vencendo ? "color:red;" : "color:black;";
            //    string conferencia = vencendo ? "RETIRAR" : (item.Conferencia ? "OK" : "F");

            //    sb.AppendLine($"<tr style='border:1px solid #000; {cor}'>");
            //    sb.AppendLine($"<td style='border:1px solid #000; padding:8px; text-align:center;'>{item.Codigo}</td>");
            //    sb.AppendLine($"<td style='border:1px solid #000; text-align:center;'>{item.Lote}</td>");
            //    sb.AppendLine($"<td style='border:1px solid #000; text-align:center;'>{item.Quantidade}</td>");
            //    sb.AppendLine($"<td style='border:1px solid #000; text-align:center;'>{item.Validade:dd/MM/yyyy}</td>");
            //    sb.AppendLine($"<td style='border:1px solid #000; text-align:center;'>{conferencia}</td>");
            //    sb.AppendLine("</tr>");
            //}

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            sb.AppendLine("<br/>");


            // ================= OBSERVAÇÕES =================
            sb.AppendLine("<div class='naoQuebrar'>");

            sb.AppendLine("<div style='font-size:15px;'>");
            sb.AppendLine($"<h3>OBSERVAÇÕES: OBS AQUI</h3>");
            sb.AppendLine($"<h3>DATA DO INVENTÁRIO: {DateTime.UtcNow.ToString("dd/MM/yyyy")}</h3>");
            sb.AppendLine("</div>");


            // ================= ASSINATURAS =================
            sb.AppendLine("<div style='display:flex; justify-content:space-between; margin-top:20px;'>");

            // Responsável
            sb.AppendLine("<div style='display:flex; flex-direction:column;'>");
            sb.AppendLine($"<p><strong>RESPONSÁVEL:</strong> nome do responsavel aqui</p>");
            sb.AppendLine($"<div><strong>ASSINATURA:</strong><br/><img src='assin' style='width:120px; height:auto;' /></div>");
            sb.AppendLine("</div>");

            // Cliente
            sb.AppendLine("<div style='display:flex; flex-direction:column;'>");
            sb.AppendLine($"<p><strong>NOME DO CLIENTE:</strong> nome cliente</p>");
            sb.AppendLine($"<div><strong>ASSINATURA:</strong><br/><img src='assinatura cliente' style='width:120px; height:auto;' /></div>");
            sb.AppendLine("</div>");

            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
