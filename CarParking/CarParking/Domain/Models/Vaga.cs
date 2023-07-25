using System.ComponentModel.DataAnnotations.Schema;

namespace CarParking.Domain.Models
{
    public class Vaga
    {
        public long Id { get; private set; }
        public int Numero { get; private set; }

        public int SetorId { get; private set; }
        public Setor Setor { get; private set; }

        public bool Ocupado { get; private set; } // TODO: Criar um status para vaga futuramente

        [NotMapped]
        public string Sigla => $"{Setor?.Sigla}{Numero}";

        public Vaga()
        {
        }

        public Vaga(int numero, int setorId)
        {
            Numero = numero;
            SetorId = setorId;
        }

        public void AtualizarStatus(bool ocupado) => Ocupado = ocupado;
    }
}
