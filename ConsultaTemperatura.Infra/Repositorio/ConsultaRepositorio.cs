using ConsultaTemperatura.Dominio.Entidade;
using ConsultaTemperatura.Dominio.Interface.Repositorio;
using ConsultaTemperatura.Infra.Contexto;
using System;
using System.Linq;

namespace ConsultaTemperatura.Infra.Repositorio
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly ConsultaContexto _contexto;

        public ConsultaRepositorio(ConsultaContexto contexto)
        {
            _contexto = contexto;
        }

        public Consulta Salvar(Consulta consulta)
        {
            Consulta exiteConsulta = BuscarPorCidade(consulta.Cidade);

            if (exiteConsulta is null)
            {
                _contexto.Consulta.Add(consulta);
                _contexto.SaveChanges();
                return consulta;
            }

            exiteConsulta.TemperaturaAtual = consulta.TemperaturaAtual;
            exiteConsulta.TemperaturaMaxima = consulta.TemperaturaMaxima;
            exiteConsulta.TemperaturaMinima = consulta.TemperaturaMinima;
            exiteConsulta.UltimaConsulta = DateTime.Now;

            _contexto.Consulta.Update(exiteConsulta);
            _contexto.SaveChanges();
            return exiteConsulta;
        }

        public Consulta BuscarPorCidade(string cidade) => _contexto.Consulta.Where(i => i.Cidade.Equals(cidade)).FirstOrDefault();
    }
}
