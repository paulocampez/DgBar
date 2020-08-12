import { useState } from "react";

export function useComanda() {
  const [numeroComanda, setNumeroComanda] = useState(0);
  return {
    numeroComanda,
    setNumeroComanda
  };
}
