namespace apiEstudo.Domain.DTOs
{
    public interface IBaseDTO<TDTO> where TDTO : IBaseDTO<TDTO>
    {
    }
}
