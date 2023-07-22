namespace CarParking.Domain.Models
{
    public class Setor
    {
        public int Id { get; private set; }
        public string Sigla { get; private set; }

        public ICollection<Vaga> Vagas { get; private set; }

        public Setor()
        {
            Vagas = new List<Vaga>();
        }

        public Setor(string sigla, Vaga vaga)
            : this()
        {
            Sigla = sigla;
            Vagas.Add(vaga);
        }

        public void Atualizar(string sigla)
        {
            Sigla = sigla;
        }

        private Vaga ObterVaga(int numero) => Vagas.FirstOrDefault(v => v.Id == numero);

        public bool VagaExistente(int numero) => Vagas.Any(v => v.Id == numero);

        public void AdicionarVaga(Vaga vaga) => Vagas.Add(vaga);

        public void RemoverVaga(int numero)
        {
            var vaga = ObterVaga(numero);

            if (vaga != null)
                Vagas.Remove(vaga);
        }
    }
}
