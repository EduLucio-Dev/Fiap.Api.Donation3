using Newtonsoft.Json;

namespace Fiap.Api.Donation3.Models
{
    public class CursoModel
    {

        [JsonProperty("nome")]
        public string Nome;

        [JsonProperty("nivel")]
        public string Nivel;

        [JsonProperty("preco")]
        public string Preco;

        [JsonProperty("conteudo")]
        public string Conteudo;

        [JsonProperty("percentualConclusao")]
        public int? PercentualConclusao;

        [JsonProperty("concluido")]
        public bool? Concluido;

        [JsonProperty("id")]
        public string Id;

    }
}