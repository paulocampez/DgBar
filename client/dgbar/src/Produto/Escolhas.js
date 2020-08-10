import React from "react";
import styled from "styled-components";

const CursorPointer = `cursor: pointer`;

const RadioInput = styled.input`
  ${CursorPointer}
`;

const Label = styled.label`
  ${CursorPointer}
`;

export function Escolhas({ abrirProduto, escolhaRadio }) {
  return (
    <>
      <h3>Choose one</h3>
      {abrirProduto.escolhas.map(escolha => (
        <>
          <RadioInput
            type="radio"
            id={escolha}
            name="escolha"
            value={escolha}
            checked={escolhaRadio.value === escolha}
            onChange={escolhaRadio.onChange}
          />
          <Label for={escolha}> {escolha} </Label>{" "}
        </>
      ))}
    </>
  );
}
