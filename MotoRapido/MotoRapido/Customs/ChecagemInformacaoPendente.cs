﻿using Matcha.BackgroundService;
using MotoRapido.ViewModels;
using System;
using System.Threading.Tasks;

namespace MotoRapido.Customs
{
    public class ChecagemInformacaoPendente : ViewModelBase,IPeriodicTask
    {
        public ChecagemInformacaoPendente() { }

        public TimeSpan Interval => TimeSpan.FromSeconds(5);

        public async Task<bool> StartJob()
        {
            ChecagemInformacaoPendenteAsync();
            
            return true;
        }

        private  void ChecagemInformacaoPendenteAsync()
        {
          
            //  var lista = ListarTodasInfoPendentes();


            //foreach(InformacaoPendente info in lista)
            //{
            //    await WebSocketClientClass.SenMessagAsync("InformacaoPendente=>"+info.servico+"=>"+info.conteudo+"=>"+info.codInformacaoPendente);
            //}

            // var response = await IniciarCliente(true).PostAsync("motorista/iniciarCorrida", content);

            // if (response.IsSuccessStatusCode)
            //  {
            //BackgroundAggregatorService.StopBackgroundService();

            //  }
        }

     
      
    }
}
