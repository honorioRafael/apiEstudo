namespace Study.Domain.DTO
{
    public class BaseInternalPropertiesDTO<TInternalPropertiesDTO>
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public BaseInternalPropertiesDTO() { }

        public BaseInternalPropertiesDTO(long id, DateTime creationDate, DateTime? changeDate)
        {
            Id = id;
            CreationDate = creationDate;
            ChangeDate = changeDate;
        }

        public TInternalPropertiesDTO SetId(long id)
        {
            Id = id;
            return (TInternalPropertiesDTO)this;
        }

        public TInternalPropertiesDTO LoadInternalData(long id, DateTime creationDate, DateTime? changeDate)
        {
            Id = id;
            CreationDate = creationDate;
            ChangeDate = changeDate;

            return (TInternalPropertiesDTO)this;
        }
    }

    public class BaseInternalPropertiesDTO_0 : BaseInternalPropertiesDTO<BaseInternalPropertiesDTO_0>
    { }
}
