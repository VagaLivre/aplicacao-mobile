using System;
using System.Collections.Generic;
using System.Text;

namespace AppTccVagalivre.Classes
{
    public class User
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public object Cidade { get; set; }
        public object UF { get; set; }
        public object Cep { get; set; }
        public int TipoUsuario { get; set; }
        public string id { get; set; }

        public string Photo { get; set; }

        public string Password { get; set; }

        public string PhotoFullpath
        {
            get

            {
                if (string.IsNullOrEmpty(this.Photo))
                {
                    return string.Empty;
                }


                return string.Format("http://www.appestapiloto.somee.com{0}", this.Photo.Substring(1));
            }
        }






    }
}
