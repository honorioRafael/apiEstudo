using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel
{
    public class MarcaViewModel : BaseViewModel<Marca>, IMarcaViewModel
    {
        public string Name { get; set; }
    }
}
