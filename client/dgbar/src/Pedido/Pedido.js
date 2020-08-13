import React, { useState, useEffect } from "react";
import styled from "styled-components";
import {
  DialogContent,
  DialogFooter,
  BotaoConfirma
} from "../Produto/Produto";
import { formatPrice } from "../Data/ProdutoData";
import { getPrice } from "../Produto/Produto";
import axios from "axios";

const PedidoStyled = styled.div`
  position: fixed;
  right: 0px;
  top: 48px;
  width: 340px;
  background-color: white;
  height: calc(100% - 48px);
  z-index: 10;
  box-shadow: 4px 0px 5px 4px grey;
  display: flex;
  flex-direction: column;
`;

const PedidoContent = styled(DialogContent)`
  padding: 20px;
  height: 100%;
`;

const PedidoContainer = styled.div`
  padding: 10px 0px;
  bpedido-bottom: 1px solid grey;
  ${({ editable }) =>
    editable
      ? `
    &:hover {
      cursor: pointer;
      background-color: #e7e7e7;
    }
  `
      : `
    pointer-events: none; 
  `}
`;

const PedidoItem = styled.div`
  padding: 10px 0px;
  display: grid;
  grid-template-columns: 20px 150px 20px 60px;
  justify-content: space-between;
`;

const DetailItem = styled.div`
  color: gray;
  font-size: 10px;
`;

export function Pedido({ pedidos, setPedidos, setAbrirProduto, numeroComanda }) {
  const subtotal = pedidos.reduce((total, pedido) => {
    return total + getPrice(pedido);
  }, 0);
  
  const total = subtotal;

  const deleteItem = index => {
    const newPedidos = [...pedidos];
    newPedidos.splice(index, 1);
    setPedidos(newPedidos);
  };
  const deleteAllItem = index => {
    const newPedidos = [...pedidos];
    newPedidos.splice(0, newPedidos.length);
    setPedidos(newPedidos);
  };
  return (
    
    <PedidoStyled>
      {(pedidos.length === 0) ? (
      <PedidoContent>seu pedido está vazio.</PedidoContent>
      ) : (
        <PedidoContent>
          {" "}
          <PedidoContainer> Seu Pedido: </PedidoContainer>{" "}
          {pedidos.map((pedido, index) => (
            <PedidoContainer editable>
              <PedidoItem
                onClick={() => {
                  setAbrirProduto({ ...pedido, index });
                }}
              >
                <div>{pedido.quantidade}</div>
                <div>{pedido.descricao}</div>
                <div
                  style={{ cursor: "pointer" }}
                  onClick={e => {
                    e.stopPropagation();
                    deleteItem(index);
                  }}
                >
                  🗑
                </div>
                {/* <div>{formatPrice(getPrice(pedido))}</div> */}
              </PedidoItem>
              <DetailItem>

              </DetailItem>
              {pedido.escolha && <DetailItem>{pedido.escolha}</DetailItem>}
            </PedidoContainer>
          ))}
          <PedidoContainer>
          </PedidoContainer>
        </PedidoContent>
      )}
      <DialogFooter>
        {numeroComanda == 0 ? (<div></div>) : (
                <BotaoConfirma onClick={() => {
                  axios({
                    headers: { 'Content-Type': 'application/json'},
                    url: 'https://localhost:5001/api/Comanda/' + numeroComanda,
                    method: 'post',
                    data: pedidos,
                    numeroComanda: numeroComanda
                  })
                  .then(function (response) {
                    if(response.data == true)
                  {
                    deleteAllItem(pedidos.length);
                    console.log(response);
                    alert("Pedido realizado !")
                  }
                     else{
                      alert("Só é permitido 3 sucos por comanda!")
                      deleteAllItem(pedidos.length);
                     }
                  })
                  .catch(function (error) {
                     // your action on error success
                      console.log(error);
                  });
                }}>{""}
                  Realizar Pedido </BotaoConfirma>
                  )}
      </DialogFooter>
    </PedidoStyled>
  );
}
