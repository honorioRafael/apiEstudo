namespace apiEstudo.Application.ViewModel
{
    public class BaseViewModel<T> : IBaseViewModel where T : IBaseViewModel
    { 
    }
    
    public interface IBaseViewModel
    {
    }
}
