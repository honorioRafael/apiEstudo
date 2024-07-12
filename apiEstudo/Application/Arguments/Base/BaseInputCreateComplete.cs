namespace apiEstudo.Application.Arguments.Base
{
    public class BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
    {
        public TInputCreate InputCreate { get; set; }
        public TInputInternalCreate InputInternalCreate { get; set; }

        public BaseInputCreateComplete() { }

        public BaseInputCreateComplete(TInputCreate inputCreate, TInputInternalCreate inputInternalCreate)
        {
            InputCreate = inputCreate;
            InputInternalCreate = inputInternalCreate;
        }
    }

    public class BaseInputCreateComplete_0 : BaseInputCreateComplete<BaseInputCreate_0, BaseInputInternalCreate_0> { }
}
