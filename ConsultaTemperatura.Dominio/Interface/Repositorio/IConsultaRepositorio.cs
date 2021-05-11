using ConsultaTemperatura.Dominio.Entidade;

namespace ConsultaTemperatura.Dominio.Interface.Repositorio
{
    public interface IConsultaRepositorio
    {
        Consulta Salvar(Consulta consulta);
        Consulta BuscarPorCidade(string cidade);
    }
}
