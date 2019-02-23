﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MotoRapido.Models
{
    public class Chamada
    {
        public Int32 codigo { get; set; }


        public DateTime dataCriacao{ get; set; }


        public DateTime dataFimCorrida{ get; set; }


        public DateTime dataInicioCorrida{ get; set; }


        public DateTime dataCancelamento{ get; set; }


        public DateTime dataInicioEspera{ get; set; }


        public Int32 pontosMotorista{ get; set; }


        public Int32 pontosUsuario{ get; set; }


        public String observacao{ get; set; }


        public String cepOrigem{ get; set; }


        public String bairroOrigem{ get; set; }


        public String cidadeOrigem{ get; set; }


        public String logradouroOrigem{ get; set; }


        public String numeroOrigem{ get; set; }

        public String complementoOrigem{ get; set; }


        public String latitudeOrigem{ get; set; }


        public String longitudeOrigem{ get; set; }


        public String cepDestino{ get; set; }


        public String bairroDestino{ get; set; }


        public String cidadeDestino{ get; set; }


        public String logradouroDestino{ get; set; }


        public String numeroDestino{ get; set; }


        public String complementoDestino{ get; set; }


        public String latitudeDestino{ get; set; }


        public String longitudeDestino{ get; set; }


        public String destinoFormatado
        {
            get { return logradouroOrigem + ";" + bairroOrigem; }
        }

    }
}