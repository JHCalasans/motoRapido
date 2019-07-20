﻿using Acr.Settings;
using Matcha.BackgroundService;
using MotoRapido.Models;
using MotoRapido.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MotoRapido.Customs
{
    public class ChecagemInformacaoPendente : ViewModelBase,IPeriodicTask
    {
        public ChecagemInformacaoPendente() { }

        public TimeSpan Interval => TimeSpan.FromSeconds(60);

        public async Task<bool> StartJob()
        {
            ChecagemInformacaoPendenteAsync();
            
            return true;
        }

        private async void ChecagemInformacaoPendenteAsync()
        {

            var lista = ListarTodasInfoPendentes();
            foreach(InformacaoPendente info in lista)
            {
                await WebSocketClientClass.SenMessagAsync("InformacaoPendente=>"+info.servico+"=>"+info.conteudo+"=>"+info.codInformacaoPendente);
            }

           // var response = await IniciarCliente(true).PostAsync("motorista/iniciarCorrida", content);
            
           // if (response.IsSuccessStatusCode)
           //  {
            //BackgroundAggregatorService.StopBackgroundService();

          //  }
        }

     
      
    }
}