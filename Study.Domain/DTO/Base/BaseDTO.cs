using Study.Arguments.Arguments;
using System.Reflection;

namespace Study.Domain.DTO
{
    public class BaseDTO<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    {
        public TExternalPropertiesDTO ExternalPropertiesDTO { get; set; }
        public TInternalPropertiesDTO InternalPropertiesDTO { get; set; }
        public TAuxiliaryPropertiesDTO AuxiliaryPropertiesDTO { get; set; }

        public BaseDTO()
        {
            ExternalPropertiesDTO = new TExternalPropertiesDTO();
            InternalPropertiesDTO = new TInternalPropertiesDTO();
            AuxiliaryPropertiesDTO = new TAuxiliaryPropertiesDTO();
        }
        #region Create
        public TDTO Create(long id, TInputCreate inputCreate, TInternalPropertiesDTO internalPropertiesDTO = default(TInternalPropertiesDTO), TAuxiliaryPropertiesDTO auxiliaryPropertiesDTO = default(TAuxiliaryPropertiesDTO))
        {
            foreach (PropertyInfo item in ExternalPropertiesDTO.GetType().GetProperties().ToList())
            {
                var propertyValue = inputCreate.GetType().GetProperty(item.Name)?.GetValue(inputCreate);

                if (propertyValue != null)
                    item.SetValue(ExternalPropertiesDTO, propertyValue);
            }

            if (internalPropertiesDTO != null)
                InternalPropertiesDTO = internalPropertiesDTO;
            else
                InternalPropertiesDTO = new TInternalPropertiesDTO();
            InternalPropertiesDTO.SetId(id);

            if (auxiliaryPropertiesDTO != null)
                AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

            return this as TDTO;
        }

        public TDTO Create(long id, TExternalPropertiesDTO externalPropertiesDTO, TInternalPropertiesDTO internalPropertiesDTO = default(TInternalPropertiesDTO), TAuxiliaryPropertiesDTO auxiliaryPropertiesDTO = default(TAuxiliaryPropertiesDTO))
        {
            ExternalPropertiesDTO = externalPropertiesDTO;
            if (internalPropertiesDTO != null)
                InternalPropertiesDTO = internalPropertiesDTO;
            else
                InternalPropertiesDTO = new TInternalPropertiesDTO();
            InternalPropertiesDTO.SetId(id);

            if (auxiliaryPropertiesDTO != null)
                AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

            return this as TDTO;
        }

        public TDTO Create(long id, TInternalPropertiesDTO internalPropertiesDTO = default(TInternalPropertiesDTO), TAuxiliaryPropertiesDTO auxiliaryPropertiesDTO = default(TAuxiliaryPropertiesDTO))
        {
            if (internalPropertiesDTO != null)
                InternalPropertiesDTO = internalPropertiesDTO;
            else
                InternalPropertiesDTO = new TInternalPropertiesDTO();
            InternalPropertiesDTO.SetId(id);

            if (auxiliaryPropertiesDTO != null)
                AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

            return this as TDTO;
        }

        #endregion

        #region Update

        public TDTO Update(TInputUpdate inputUpdate, TInternalPropertiesDTO internalPropertiesDTO = default(TInternalPropertiesDTO), TAuxiliaryPropertiesDTO auxiliaryPropertiesDTO = default(TAuxiliaryPropertiesDTO))
        {
            foreach (PropertyInfo item in ExternalPropertiesDTO.GetType().GetProperties().ToList())
            {
                var propertyValue = inputUpdate.GetType().GetProperty(item.Name)?.GetValue(inputUpdate);

                if (propertyValue != null)
                    item.SetValue(ExternalPropertiesDTO, propertyValue);
            }

            if (internalPropertiesDTO != null)
                InternalPropertiesDTO = internalPropertiesDTO;

            if (auxiliaryPropertiesDTO != null)
                AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

            return this as TDTO;
        }

        #endregion
    }


    public class BaseDTO_1<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : BaseDTO<BaseInputCreate_0, BaseInputUpdate_0, TOutput, TDTO, BaseExternalPropertiesDTO_0, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO_1<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    { }

    public class BaseDTO_2<TOutput, TDTO, TInternalPropertiesDTO> : BaseDTO<BaseInputCreate_0, BaseInputUpdate_0, TOutput, TDTO, BaseExternalPropertiesDTO_0, TInternalPropertiesDTO, BaseAuxiliaryPropertiesDTO_0>
    where TOutput : BaseOutput<TOutput>
    where TDTO : BaseDTO_2<TOutput, TDTO, TInternalPropertiesDTO>
    where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
    { }

    public class BaseDTO_0 : BaseDTO_1<BaseOutput_0, BaseDTO_0, BaseInternalPropertiesDTO_0, BaseAuxiliaryPropertiesDTO_0> { }
}
