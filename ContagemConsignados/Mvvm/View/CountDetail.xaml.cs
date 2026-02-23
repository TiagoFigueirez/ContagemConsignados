using ContagemConsignados.Mvvm.ViewModel;
using ContagemConsignados.Services;
using ContagemConsignados.Services.Interface;
using System.Runtime.CompilerServices;
namespace ContagemConsignados.Mvvm.View;
public partial class CountDetail : ContentPage
{
    private readonly CountDetailViewModel _vm;

    public CountDetail(CountDetailViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.InitializeAsync();
    }
}