using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Domain.Commands
{
    public class CadastrarNovoProdutoCommand : ProdutoCommand
    {
        public CadastrarNovoProdutoCommand(string descricao)
        {
            Descricao = descricao;
        }
    }
}
