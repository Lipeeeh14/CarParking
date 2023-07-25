using System.ComponentModel.DataAnnotations.Schema;

namespace CarParkingControl.Domain.Models
{
	public class RegistroVaga
	{
		public long Id { get; private set; }
        public long VagaId { get; private set; }
        public string PlacaVeiculo { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataSaida { get; private set; }
        public bool Mensalista { get; private set; }

        [NotMapped]
        public decimal? Valor { get; private set; }

        [NotMapped]
        public bool Ativa => !DataSaida.HasValue;

        public RegistroVaga()
		{
			PlacaVeiculo = "";
			DataEntrada = DateTime.Now;
		}

		public RegistroVaga(long vagaId, string placaCarro, bool mensalista) : this()
		{
			VagaId = vagaId;
			PlacaVeiculo = placaCarro;
			Mensalista = mensalista;
		}

		public void RegistrarSaida()
		{
			DataSaida = DateTime.Now;
		}
	}
}
