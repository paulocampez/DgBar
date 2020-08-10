import { useState } from "react";

export function useAbrirProduto() {
  const [abrirProduto, setAbrirProduto] = useState();
  return {
    abrirProduto,
    setAbrirProduto
  };
}
