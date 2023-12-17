using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Domain.Dtos;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Services.Service;
using System.Collections.Generic;

namespace ProjetoFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public List<ClienteDto> Get()
        {
            try
            {
                List<Cliente> clientes = _clienteService.Listar();
                List<ClienteDto> clienteDtos = 
                    clientes !=null ? Cliente.ConverterParaDto(clientes) : null;
                
                return clienteDtos;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public string Get()
        //{
        //    return "A aplicacao esta funcionando!";
        //}
    }
}
