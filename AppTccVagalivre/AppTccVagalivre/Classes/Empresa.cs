using System;
using System.Collections.Generic;
using System.Text;

namespace AppTccVagalivre.Classes
{
  public  class Empresa
    {
        public List<Empresa> Empresalocalizadas { get; set; }
        public int EmpresaId { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public object Teste { get; set; }
        public int NVagas { get; set; }
        public int NDispo { get; set; }
        public decimal Valor { get; set; }
        public TimeSpan Horafi { get; set; }
        public TimeSpan Horai { get; set; }
        public bool Seg { get; set; }
        public bool TER { get; set; }
        public bool Qua { get; set; }
        public bool Qui { get; set; }
        public bool Sex { get; set; }
        public bool Sab { get; set; }
        public bool Dom { get; set; }


        
    }
}
