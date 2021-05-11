using ConsultaTemperatura.Dominio.Entidade;
using ConsultaTemperatura.Dominio.Interface.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsultaTemperatura.API.Controllers
{
    [Route("api/consultaTemperatura")]
    public class ConsultaController : Controller
    {
        private readonly IConsultaRepositorio _repositorio;
        private const string URL = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&lang=pt_br";
        private const string CHAVE = "9a491e7b75267d4552d4a3cf990b0aea";
        private string cidade = string.Empty;

        public ConsultaController(IConsultaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{cidade}")]
        public async Task<IActionResult> Get(string cidade)
        {
            try
            {
                this.cidade = cidade;
                Consulta consulta = _repositorio.BuscarPorCidade(cidade);

                if (consulta is null || consulta.UltimaConsulta.AddMinutes(20) <= DateTime.Now)
                {
                    consulta = await GetConsultaApi();
                }

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<Consulta> GetConsultaApi()
        {
            string novaUrl = string.Format(URL, cidade, CHAVE);

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(novaUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Root retorno = JsonConvert.DeserializeObject<Root>(json);

                Consulta consulta = new Consulta
                {
                    TemperaturaAtual = retorno.main.temp,
                    TemperaturaMaxima = retorno.main.temp_max,
                    TemperaturaMinima = retorno.main.temp_min,
                    Cidade = cidade,
                };

                Consulta consultaSalva = _repositorio.Salvar(consulta);

                if (consultaSalva is null)
                {
                    throw new Exception("Não foi possível salvar a busca realizada.");
                }

                consulta.Id = consultaSalva.Id;
                consulta.UltimaConsulta = consultaSalva.UltimaConsulta;
                return consulta;
            }
            else
            {
                throw new Exception("Não foi possível realizar a busca com a cidade informada.");
            }
        }
    }
}


