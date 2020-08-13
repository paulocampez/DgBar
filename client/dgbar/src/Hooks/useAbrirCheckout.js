import { useState } from "react";

export function useAbrirCheckout() {
  const [abrirCheckout, setAbrirCheckout] = useState();
  return {
    abrirCheckout,
    setAbrirCheckout
  };
}
