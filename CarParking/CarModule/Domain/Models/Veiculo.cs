namespace CarModule.Domain.Models
{
	public class Veiculo
	{
        public string? Placa { get; private set; }
        public string? Modelo { get; private set; }
        public string? Marca { get; private set; }

        public long ProprietarioId { get; private set; }
        public Proprietario Proprietario { get; private set; }

        public Veiculo() { }

		public Veiculo(string? placa, string? modelo, string? marca)
		{
			Placa = placa;
			Modelo = modelo;
			Marca = marca;
		}
	}
}
