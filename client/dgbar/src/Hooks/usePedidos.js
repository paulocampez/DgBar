import { useState } from "react";

export function usePedidos() {
  const [pedidos, setPedidos] = useState([]);
  return {
    pedidos,
    setPedidos
  };
}
