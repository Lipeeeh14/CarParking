namespace CarModule.Domain.Models
{
	public class Proprietario
	{
        public long Id { get; private set; }
        public string? Nome { get; private set; }
        public string? CPF { get; private set; }
        public ICollection<Veiculo> Veiculos { get; private set; }

		public Proprietario()
		{
			Veiculos = new List<Veiculo>();
		}

		public Proprietario(string? nome, string? cpf) : this()
		{
			Nome = nome;
			CPF = cpf;
		}
	}
}
