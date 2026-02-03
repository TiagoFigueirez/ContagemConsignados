using SQLite;

namespace ContagemConsignados.Mvvm.Model
{
    public class CountModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateCount { get; set; }
        public string? Email { get; set; }
        public string? Observer { get; set; }
        public int Status { get; set; }
        
    }
}
