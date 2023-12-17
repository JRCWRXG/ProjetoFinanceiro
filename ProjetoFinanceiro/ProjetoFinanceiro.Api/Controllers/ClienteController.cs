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


        [HttpGet]
        [Route("{Id}")]
        public ClienteDto Get(int Id)
        {
            try
            {
                Cliente cliente = _clienteService.Pesquisar(Id);
                 ClienteDto clienteDto = cliente != null ? cliente.ConverterParaDto() : null;

                //ClienteDto clienteDto = null;
                //if (clienteDto != null) 
                //{
                //    clienteDto = cliente.ConverterParaDto();
                //}

                return clienteDto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public string Post([Bind("Nome, cpf")]ClienteDto clienteDto)
        {
            try
            {
                Cliente cliente = clienteDto.ConverterParaEntidade();
                _clienteService.Salvar(cliente);

                return $"Cliente {cliente.Nome} cadastrado com sucesso, id  {cliente.Clienteid}";
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
