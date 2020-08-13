import React from "react";
import styled from "styled-components";
import { ProdutoLabel } from "../Menu/ProdutoGrid";
import { Title } from "../Styles/title";
import { Quantidade } from "../Produto/Quantidade";
import { useQuantidade } from "../Hooks/useQuantidade";
import { useEscolha } from "../Hooks/useEscolha";
import { useComanda } from "../Hooks/useComanda";

const Dialog = styled.div`
  width: 1500px;
  background-color: white;
  position: fixed;
  top: 75px;
  z-index: 5;
  max-height: calc(100% - 100px);
  left: calc(150px);
  display: flex;
  flex-direction: column;
`;

export const DialogContent = styled.div`
  overflow: auto;
  min-height: 100px;
  padding: 0px 40px;
  padding-bottom: 80px;
`;

export const DialogFooter = styled.div`
  box-shadow: 0px -2px 10px 0px grey;
  height: 60px;
  display: flex;
  justify-content: center;
`;
export const BotaoReset = styled(Title)`
  margin: 10px;
  color: white;
  height: 20px;
  bpedido-radius: 5px;
  padding: 10px;
  text-align: center;
  width: 200px;
  cursor: pointer;
  background-color: #02020A;
  ${({ disabled }) =>
    disabled &&
    `
    opactity: .5; 
    background-color: grey; 
    pointer-events: none; 
  `}
`;
export const BotaoConfirma = styled(Title)`
  margin: 10px;
  color: white;
  height: 20px;
  bpedido-radius: 5px;
  padding: 10px;
  text-align: center;
  width: 200px;
  cursor: pointer;
  background-color: #02020A;
  ${({ disabled }) =>
    disabled &&
    `
    opactity: .5; 
    background-color: grey; 
    pointer-events: none; 
  `}
`;

const DialogShadow = styled.div`
  position: fixed;
  height: 100%;
  width: 100%;
  top: 0px;
  background-color: black;
  opacity: 0.7;
  z-index: 4;
`;

const DialogBanner = styled.div`
  min-height: 200px;
  margin-bottom: 20px;
  ${({ img }) => (img ? `background-image: url(${img});` : `min-height: 75px;`)}
  background-position: center;
  background-size: cover;
`;

const DialogBannerName = styled(ProdutoLabel)`
  font-size: 30px;
  padding: 5px 40px;
  top: ${({ img }) => (img ? `100px` : `20px`)};
`;

function CheckoutContainer({ abrirCheckout, setAbrirCheckout, setPedidos, pedidos, setComanda }) {
  // const quantidade = useQuantidade(abrirProduto && abrirProduto.quantidade);
  const comanda = useComanda();
  const numero = setComanda;
  function close() {
    setAbrirCheckout();
  }

  const pedido = { 
     ...abrirCheckout.data.produtos,
    // quantidade: quantidade.value,
    // numero: numero,
    // total: ...abrirCheckout,
    teste: comanda
  };

  return (
    <>
      <DialogShadow onClick={close} />
      <Dialog>
        <DialogBanner >
          <DialogBannerName> {"Comanda"} </DialogBannerName>
        </DialogBanner>
        <DialogContent>
          {abrirCheckout.data.produtos.map((pedido, index) => (
            <div>{pedido.descricao}{" - Quantidade: "}{pedido.quantidade}{" - Valor: "}{pedido.valor} {pedido.observacao == null ? "" : (" - Obs: " + pedido.observacao)}</div>
          ))}
          {<div>{"---------------------------------------------------"}</div>}
          {<div>{"Descontos: R$"}{abrirCheckout.data.desconto}</div>}
          {<div>{"Total: R$"}{abrirCheckout.data.total}</div>}
        </DialogContent>
        <DialogFooter>
          <BotaoConfirma
            onClick={close}
          >
            {`Pagar: R$`}
            {abrirCheckout.data.total}
          </BotaoConfirma>
        </DialogFooter>
      </Dialog>
    </>
  );
}

export function Checkout(props) {
  if (!props.abrirCheckout) return null;
  return <CheckoutContainer {...props} />;
}
