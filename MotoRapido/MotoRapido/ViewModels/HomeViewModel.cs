﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using Acr.Settings;
using Acr.UserDialogs;
using MotoRapido.Models;
using MotoRapido.Views;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace MotoRapido.ViewModels
{
	public class HomeViewModel : ViewModelBase
    {
        public DelegateCommand DisponibilidadeCommand => new DelegateCommand(AlterarDisponibilidade);

        private ImageSource _imgDisponibilidade;

        public ImageSource ImgDisponibilidade
        {
            get { return _imgDisponibilidade; }
            set { SetProperty(ref _imgDisponibilidade, value); }
        }

        private Boolean _estaLivre;

        public Boolean EstaLivre
        {
            get { return _estaLivre; }
            set { SetProperty(ref _estaLivre, value); }
        }

        public HomeViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (MotoristaLogado.disponivel.Equals("S"))
            {
                ImgDisponibilidade = ImageSource.FromResource("MotoRapido.Imagens.btn_ocupado.png");
                EstaLivre = true;
            }
            else
            {
                ImgDisponibilidade = ImageSource.FromResource("MotoRapido.Imagens.btn_disponivel.png");
                EstaLivre = false;
            }


        }

        private async void AlterarDisponibilidade()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando...");

                var response = await IniciarCliente(true).GetAsync("motorista/alterarDisponivel?codMotorista="+ MotoristaLogado.codigo);

                Motorista motoTemp = new Motorista();
                motoTemp = MotoristaLogado;
                if (response.IsSuccessStatusCode)
                {
                    if (motoTemp.disponivel.Equals("S"))
                    {
                        motoTemp.disponivel = "N";
                        ImgDisponibilidade = ImageSource.FromResource("MotoRapido.Imagens.btn_disponivel.png");
                        EstaLivre = false;
                    }
                    else
                    {
                        motoTemp.disponivel = "S";
                        ImgDisponibilidade = ImageSource.FromResource("MotoRapido.Imagens.btn_ocupado.png");
                        EstaLivre = true;
                    }

                    Settings.Current.Set("MotoristaLogado", motoTemp);
                    // await DialogService.DisplayAlertAsync("Aviso", "Mudou", "OK");
                }
                else
                {
                    await DialogService.DisplayAlertAsync("Aviso", response.Content.ReadAsStringAsync().Result, "OK");
                }

            }
            catch (Exception e)
            {
                await DialogService.DisplayAlertAsync("Aviso", "Falha ao alterar disponibilidade", "OK");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}