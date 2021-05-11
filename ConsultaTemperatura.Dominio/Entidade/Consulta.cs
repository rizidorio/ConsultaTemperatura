using System;

namespace ConsultaTemperatura.Dominio.Entidade
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }
        public decimal TemperaturaAtual { get; set; }
        public DateTime UltimaConsulta { get; set; }

        public Consulta()
        {
            Id = 0;
            Cidade = string.Empty;
            TemperaturaMinima = 0m;
            TemperaturaMaxima = 0m;
            TemperaturaAtual = 0m;
            UltimaConsulta = DateTime.Now;
        }
    }
}
