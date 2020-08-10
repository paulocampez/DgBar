import React from "react";
import styled from "styled-components";
import { Title } from "../Styles/title";

const QuantidadeInputStyled = styled.input`
  font-size: 18px;
  width: 24px;
  text-align: center;
  bpedido: none;
  outline: none;
`;

const IncrementContainer = styled(Title)`
  display: flex;
  height: 24px;
`;

const IncrementButton = styled.div`
  width: 23px;
  color: "#02020A";
  font-size: 20px;
  text-align: center;
  cursor: pointer;
  line-height: 23px;
  margin: 0px 10px;
  bpedido: 1px solid "#02020A";
  ${({ disabled }) =>
    disabled &&
    `opacity: 0.5; 
     pointer-events: none; 
     `}
  &:hover {
    background-color: #ffe3e3;
  }
`;

export function Quantidade({ quantidade }) {
  return (
    <IncrementContainer>
      <div>Quantidade:</div>
      <IncrementButton
        onClick={() => {
          quantidade.setValue(quantidade.value - 1);
        }}
        disabled={quantidade.value === 1}
      >
        -
      </IncrementButton>
      <QuantidadeInputStyled {...quantidade} />
      <IncrementButton
        onClick={() => {
          quantidade.setValue(quantidade.value + 1);
        }}
      >
        +
      </IncrementButton>
    </IncrementContainer>
  );
}
