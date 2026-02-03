using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace ContagemConsignados.Mvvm.Model
{
    public partial class Product : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        private string? codigo;

        [ObservableProperty]
        private string? lote;

        [ObservableProperty]
        private string? dataValidade;

        [ObservableProperty]
        private int quantidade;

        [ObservableProperty]
        private int countId;

    }
}
