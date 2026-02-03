namespace ContagemConsignados.Services.Interface
{
    public interface IUnitOfWork
    {
        ICountServices CountServices {  get; }
        IProductServices ProductServices {  get; }
    }
}
