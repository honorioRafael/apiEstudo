
using Study.Infrastructure.Entry.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Infrastructure.Entry
{
    public class IdControl : BaseEntry<IdControl>
    {
        #region Not Mapped
        [NotMapped]
        public override DateTime? ChangeDate { get => base.ChangeDate; protected set => base.ChangeDate = value; }
        [NotMapped]
        public override DateTime CreationDate { get => base.CreationDate; protected set => base.CreationDate = value; }
        #endregion

        #region Properties
        public long TableKey { get; set; }
        public string TableName { get; set; }
        public long NextId { get; set; }

        #endregion

        public IdControl() { }

        public IdControl(long tableKey, string tableName, long nextId)
        {
            TableKey = tableKey;
            TableName = tableName;
            NextId = nextId;
        }
    }
}
