using CommunityToolkit.Mvvm.ComponentModel;

namespace ContagemConsignados.Mvvm.Model
{
        public partial class Product : ObservableObject
        {
            public int Id { get; set; }

            [ObservableProperty]
            private string? codigo;

            [ObservableProperty]
            private string? lote;

            [ObservableProperty]
            private string? dataValidade;

            [ObservableProperty]
            private int quantidade;
        }
}
