using PicPaySimplificado.Core.Base;

namespace PicPaySimplificado.Core.Entities
{
    public class Wallet : EntityBase
    {
        //orm
        protected Wallet()
        {
            
        }
        public Wallet(string nome, string cpf, string email, string senha, string tipoCarteira)
        {
            Name = nome;
            Cpf = cpf;
            Email = email;
            Password = senha;
            TypeWalltet = tipoCarteira;
        }

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; } = 0;
        public string TypeWalltet { get; private set; }

        public decimal SubtractBalance(decimal amount)
        {
            return Balance -= amount;
        }

        public void AddBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}
