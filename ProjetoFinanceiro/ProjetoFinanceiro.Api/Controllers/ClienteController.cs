using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Domain.Configuration;
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
        #region Propriedades
        private readonly ClienteService _clienteService;
        private readonly IApiConfig _config;  // pode remover caso queira pois nao esta sendo mais usado

        #endregion


        #region Construtores
        public ClienteController(ClienteService clienteService, IApiConfig _config)
        {
            _clienteService = clienteService;
            this._config = _config;
        }

        #endregion


        #region Actions

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
        [HttpPut]
      
        
        public string Put([FromBody]ClienteDto clienteDto) 
        {
            try
            {
                Cliente cliente = clienteDto.ConverterParaEntidade();
                _clienteService.Atualizar(cliente);


                return $"Cliente {cliente.Nome} atualizado com sucesso, id  {cliente.Clienteid}";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public string Delete(int id)
        {
            try
            {
              
                _clienteService.Excluir(id);


                return $"Cliente Excluido com sucesso, id {id} ";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        //public string Get()
        //{
        //    return "A aplicacao esta funcionando!";
        //}
    }
}
