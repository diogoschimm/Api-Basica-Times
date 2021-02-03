namespace ApiCrud.Models
{
    public class Jogo
    {
        public int IdJogo { get; set; }

        public int IdTimeMandante { get; set; }
        public int QtdGolsTimeMandante { get; set; }

        public int IdTimeVisitante { get; set; }
        public int QtdGolsTimeVisitante { get; set; }
    }
}
