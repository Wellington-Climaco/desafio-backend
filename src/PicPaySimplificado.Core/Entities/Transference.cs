using PicPaySimplificado.Core.Base;
using PicPaySimplificado.Core.Enum;

namespace PicPaySimplificado.Core.Entities
{
    public class Transference : EntityBase
    {


        //orm
        protected Transference() { }

        public Transference(StatusTransaction status, decimal value, Wallet payeer, Wallet reciver)
        {
            Status = status.ToString();
            Value = value;
            Payeer = payeer;
            Reciver = reciver;
        }

        public string Status { get; set; }
        public decimal Value { get; set; }

        public Wallet Payeer { get; set; }
        public Guid PayeerId { get; set; }

        public Wallet Reciver { get; set; }
        public Guid ReciverId { get; set; }


        public void ChangeStatus(StatusTransaction status)
        {
            Status = status.ToString();
        }

    }
}
