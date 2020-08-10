import { useState } from "react";

export function useQuantidade(defaultQuantidade) {
  const [value, setValue] = useState(defaultQuantidade || 1);

  function onChange(e) {
    if (!(+e.target.value >= 1)) {
      setValue(1);
      return;
    }
    setValue(+e.target.value);
  }

  return {
    value,
    setValue,
    onChange
  };
}
