using System.Text.Json.Serialization;

namespace apiEstudo.Application.Arguments
{
    public class OutputShippingStatus : BaseOutput<OutputShippingStatus>
    {
        [JsonIgnore]
        public override DateTime? ChangeDate { get => base.ChangeDate; set => base.ChangeDate = value; }
        [JsonIgnore]
        public override DateTime? CreationDate { get => base.CreationDate; set => base.CreationDate = value; }

        public string Description { get; set; }

        public OutputShippingStatus()
        { }

        public OutputShippingStatus(long id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
