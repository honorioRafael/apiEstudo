namespace apiEstudo.Application.Arguments.Base
{
    public class BaseInputInternalCreate<TInputInternalCreate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
    {
    }

    public class BaseInputInternalCreate_0 : BaseInputInternalCreate<BaseInputInternalCreate_0> { }
}
