import React from "react";
import styled from "styled-components";
import { ProdutoLabel } from "../Menu/ProdutoGrid";
import { Title } from "../Styles/title";
import { formatPrice } from "../Data/ProdutoData";
import { Quantidade } from "./Quantidade";
import { useQuantidade } from "../Hooks/useQuantidade";
import { useEscolha } from "../Hooks/useEscolha";
import { useComanda } from "../Hooks/useComanda";
import { Escolhas } from "./Escolhas";

const Dialog = styled.div`
  width: 500px;
  background-color: white;
  position: fixed;
  top: 75px;
  z-index: 5;
  max-height: calc(100% - 100px);
  left: calc(50% - 250px);
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


export function getPrice(pedido) {
  return (
    pedido.quantidade *
    (pedido.valor)
  );
}


function ProdutoContainer({ abrirProduto, setAbrirProduto, setPedidos, pedidos, setComanda }) {
  const quantidade = useQuantidade(abrirProduto && abrirProduto.quantidade);
  const escolhaRadio = useEscolha(abrirProduto.escolha);
  const comanda = useComanda();
  const isEditing = abrirProduto.index > -1;
  const numero = setComanda;
  function close() {
    setAbrirProduto();
  }

  const pedido = {
    ...abrirProduto,
    quantidade: quantidade.value,
    escolha: escolhaRadio.value,
    numero: numero,
    teste: comanda
  };

  function editPedido() {
    const newPedidos = [...pedidos];
    newPedidos[abrirProduto.index] = pedido;
    setPedidos(newPedidos);
    close();
  }

  function addToPedido() {
    setPedidos([...pedidos, pedido]);
    close();
  }

  return (
    <>
      <DialogShadow onClick={close} />
      <Dialog>
        <DialogBanner img={abrirProduto.img}>
          <DialogBannerName> {abrirProduto.descricao} </DialogBannerName>
        </DialogBanner>
        <DialogContent>
          <Quantidade quantidade={quantidade} />

          {abrirProduto.escolhas && (
            <Escolhas abrirProduto={abrirProduto} escolhaRadio={escolhaRadio} />
          )}
        </DialogContent>
        <DialogFooter>
          <BotaoConfirma
            onClick={isEditing ? editPedido : addToPedido}
            disabled={abrirProduto.escolhas && !escolhaRadio.value}
          >
            {isEditing ? `Atualizar: ` : `Adicionar: `}
            {formatPrice(getPrice(pedido))}
          </BotaoConfirma>
        </DialogFooter>
      </Dialog>
    </>
  );
}

export function Produto(props) {
  if (!props.abrirProduto) return null;
  return <ProdutoContainer {...props} />;
}
