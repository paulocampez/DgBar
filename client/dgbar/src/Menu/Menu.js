import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { produtos } from "../Data/ProdutoData";
import ReactDOM from "react-dom";
import { ProdutoConfig, ProdutoGrid, ProdutoLabel } from "./ProdutoGrid";
import { formatPrice } from "../Data/ProdutoData";
import {
  BotaoConfirma
} from "../Produto/Produto";
const MenuStyled = styled.div`
  height: 1000px;
  margin: 0px 400px 50px 20px;
`;

export function Menu({ setAbrirProduto }) {

  const [produtosList, setAbrirProdutos] = useState([]);
  
  useEffect(() => {
    fetch(
      `http://localhost:5001/api/Produto/all`,
      {
        method: "GET"
      }
    )
      .then(res => res.json())
      .then(response => {
        setAbrirProdutos(response);
      })
      .catch(error => console.log(error));
  });
  
  return (
    <MenuStyled>
        <>
          <ProdutoGrid>
            
            {produtosList.map(produto => (
              <ProdutoConfig
                img={produto.img}
                onClick={() => {
                  setAbrirProduto(produto);
                }}
              >
                <ProdutoLabel>
                  <div>{produto.descricao}</div>
                  <div>{formatPrice(produto.valor)}</div>
                </ProdutoLabel>
              </ProdutoConfig>
            ))}
          </ProdutoGrid>
          
        </>
    </MenuStyled>
  );
}
