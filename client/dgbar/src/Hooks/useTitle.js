import { useEffect } from "react";

export function useTitle({ abrirProduto, pedidos }) {
  useEffect(() => {
    if (abrirProduto) {
      document.title = abrirProduto.descricao;
    } else {
      document.title =
        pedidos.length === 0
          ? `Qual produto deseja?`
          : `[${pedidos.length}] Itens no seu pedido! `;
    }
  });
}
