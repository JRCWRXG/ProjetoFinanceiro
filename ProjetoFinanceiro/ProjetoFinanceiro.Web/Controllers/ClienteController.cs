﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoFinanceiro.Web.Models;
using System.Text;

namespace ProjetoFinanceiro.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly string ENDPOINT = "http://localhost:5025/api/cliente/";
        private readonly HttpClient _httpClient = null;

        public ClienteController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ENDPOINT);
        }

        public async Task<IActionResult> Index()
        {

            try
            {
                List<ClienteViewModel> clientes = null;

                HttpResponseMessage response = await _httpClient.GetAsync(ENDPOINT);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync(); 
                  clientes = JsonConvert.DeserializeObject<List<ClienteViewModel>>(content);   
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitacao");
                }

                return View(clientes);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }


        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ClienteViewModel result = await Pesquisar(id);
                
                return View(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public IActionResult Create()
        { 
        return View();  
        }


        [HttpPost]
        public async Task <IActionResult> Create([Bind("Nome, Cpf")]ClienteViewModel cliente)
        {
            try
            {
                string json = JsonConvert.SerializeObject(cliente);
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer); 
                byteArrayContent.Headers.ContentType = 
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                string url = ENDPOINT;  
                HttpResponseMessage response =
                    await _httpClient.PostAsync(url, byteArrayContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Erro ao processar a solicitacao");

                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private async Task<ClienteViewModel> Pesquisar(int id)
        {
            try
            {
                ClienteViewModel result = null;

                string url = $"{ENDPOINT}{id}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ClienteViewModel>(content);
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitacao");
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
