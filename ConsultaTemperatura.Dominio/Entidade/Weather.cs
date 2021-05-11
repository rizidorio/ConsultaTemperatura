namespace ConsultaTemperatura.Dominio.Entidade
{
    public class Main
    {
        public decimal temp { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
    }

    public class Root
    {
        public Main main { get; set; }
    }
}
