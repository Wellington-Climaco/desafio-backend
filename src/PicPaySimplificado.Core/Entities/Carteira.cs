namespace PicPaySimplificado.Core.Entities
{
    public class Carteira
    {
        protected Carteira()
        {
            
        }
        public Carteira(string nome, string cpf, string email, string senha, string tipoCarteira)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Senha = senha;
            Tipo = tipoCarteira;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public decimal Saldo { get; private set; } = 0;
        public string Tipo { get; private set; }
    }
}
