using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovoBanco.Aplicacao.Shared
{
    public class Util
    {
        public static IEnumerable<SelectListItem> DaClasseComOpcaoPadrao<T>(string texto, string valor, Func<IEnumerable<T>> metodoDeBuscaDaLista, int valorSelecionado = 0) where T : class
        {
            var lista = new List<SelectListItem> { new SelectListItem { Text = "Selecione", Value = string.Empty } };
            var listaDeObjetosRetornados = metodoDeBuscaDaLista.Invoke();
            lista.AddRange(PreencherSelectList<T>(listaDeObjetosRetornados, texto, valor, valorSelecionado));

            return lista;
        }

        private static IEnumerable<SelectListItem> PreencherSelectList<T>(IEnumerable<T> lista, string texto, string valor, int valorSelecionado) where T : class
        {
            var listaDeRetorno = new List<SelectListItem>();

            if (lista == null || !lista.Any())
                return listaDeRetorno;

            foreach (var item in lista)
            {
                var tipoDoItem = item.GetType();
                var textoDoItem = tipoDoItem.GetProperty(texto);
                var valorDoItem = tipoDoItem.GetProperty(valor);
                var selecionado = valorDoItem?.GetValue(item).ToString() == valorSelecionado.ToString();

                listaDeRetorno.Add(new SelectListItem
                {
                    Text = textoDoItem?.GetValue(item).ToString(),
                    Value = valorDoItem?.GetValue(item).ToString(),
                    Selected = selecionado
                });
            }

            return listaDeRetorno;
        }
    }
}
