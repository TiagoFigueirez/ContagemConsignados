using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace ContagemConsignados.Mvvm.Model
{
    public partial class CountModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        public string? hospital; 

        [ObservableProperty]
        private DateTime? dateCount;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? signatureConferente;

        [ObservableProperty]
        private string? signatureCliente;

        [ObservableProperty]
        private string? clienteName;

        [ObservableProperty]
        private string? observer;

        [ObservableProperty]
        private int status;
    }
}
