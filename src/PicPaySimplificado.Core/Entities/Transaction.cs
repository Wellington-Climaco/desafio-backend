using PicPaySimplificado.Core.Base;
using PicPaySimplificado.Core.Enum;

namespace PicPaySimplificado.Core.Entities
{
    public class Transaction : EntityBase
    {


        //orm
        protected Transaction() { }

        public Transaction(StatusTransaction status, decimal value, Wallet payeer, Wallet reciver)
        {
            Status = status;
            Value = value;
            Payeer = payeer;
            Reciver = reciver;
        }

        public StatusTransaction Status { get; set; }
        public decimal Value { get; set; }

        public Wallet Payeer { get; set; }
        public Guid PayeerId { get; set; }

        public Wallet Reciver { get; set; }
        public Guid ReciverId { get; set; }

    }
}
