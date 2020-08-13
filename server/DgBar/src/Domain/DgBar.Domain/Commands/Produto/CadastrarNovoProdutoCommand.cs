using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Commands
{
    public class CadastrarNovoProdutoCommand : ProdutoCommand
    {
        public CadastrarNovoProdutoCommand(string descricao, int valor, int quantidade, int desconto, string observacao)
        {
            Descricao = descricao;
            Valor = valor;
            Quantidade = quantidade;
            Desconto = desconto;
            Observacao = observacao;
        }
    }
}
