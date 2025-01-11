namespace PicPaySimplificado.Core.Base
{
    public class EntityBase
    {
        public Guid Id { get;  private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
