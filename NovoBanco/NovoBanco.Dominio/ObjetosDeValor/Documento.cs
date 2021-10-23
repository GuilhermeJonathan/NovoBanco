using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio.ObjetosDeValor
{
    public class Documento
    {
        private Documento()
        {

        }

        public Documento(string numero)
        {
            if (string.IsNullOrEmpty(numero) || numero.Length < 11)
                throw new ExcecaoDeNegocio("Documento inválido. Verifique se o documento é um CPF ou CNPJ válido");

            numero = numero.Replace(".", "").Replace("/", "").Replace("-", "");
            if (numero.Length == 11)
                this.Numero = new Cpf(numero).Codigo;
            else if (numero.Length == 14)
                this.Numero = new Cnpj(numero).Codigo;
        }

        public bool EhUmCpf => !String.IsNullOrEmpty(this.Numero) ? this.Numero.Length == 11 : false;
        public bool EhUmCnpj => !String.IsNullOrEmpty(this.Numero) ? this.Numero.Length == 14 : false;

        public string Numero { get; private set; }
        public static Documento Vazio => new Documento();
    }
}
