# ConsultaTemperatura
API para consultar temperatura com os dados coletados na API do OpenWeather
Utilizando C#, .NET 5, Entity Framework Core e banco de dados MySQL.

Ao digitar a cidade será realizada uma verificação no banco se já existe uma consulta para cidade.
Se existir será verficado se a consulta foi realizada a menos de 20 minutos da hora atual e mostrará os dados salvo no banco para o usuário.
Se for a mais de 20 minutos ou a cidade informada não possuir cadastro no banco a API irá buscar os dados na API do OpenWeather e fará a atualização do banco, 
salvando a nova cidade ou atulizando a cidade existente.
