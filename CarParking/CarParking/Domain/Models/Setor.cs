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
    }
}
