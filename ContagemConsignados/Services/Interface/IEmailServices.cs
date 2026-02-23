using ContagemConsignados.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContagemConsignados.Services.Interface
{
    public interface IEmailServices
    {
        bool SubmitEmail(string emails, CountModel count, ObservableCollection<Product> products);
    }
}
