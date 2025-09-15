namespace BloodTrack.Infrastructure.ExternalServices
{
    public class ViaCepResponse
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public bool Error { get; set; }
    }
}
