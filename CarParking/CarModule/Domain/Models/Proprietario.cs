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

		public void Atualizar(string? nome, string? cpf) 
		{
			Nome = nome;	
			CPF = cpf;
		}

		public void AdicionarVeiculo(Veiculo veiculo) 
		{
			if (Veiculos.Any(v => v.Placa.Equals(veiculo.Placa))) return;
			
			Veiculos.Add(veiculo);
		}

		public bool RemoverVeiculo(string placa) 
		{
			var veiculo = Veiculos.FirstOrDefault(v => v.Placa.Equals(placa));

			if (veiculo == null) return false;

			Veiculos?.Remove(veiculo);
			return true;
		}
	}
}
