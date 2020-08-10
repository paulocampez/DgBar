import React from 'react';
import logo from './logo.svg';
import { Navbar } from "./Navbar/Navbar";
import { GlobalStyle } from "./Styles/GlobalStyle";
import './App.css';
import { Banner } from "./Banner/Banner";
import { Produto } from "./Produto/Produto";
import { Pedido } from "./Pedido/Pedido";
import { useAbrirProduto } from "./Hooks/useAbrirProduto";
import { usePedidos } from "./Hooks/usePedidos";
import { useTitle } from "./Hooks/useTitle";
import { Menu } from "./Menu/Menu";

function App() {
  const abrirProduto = useAbrirProduto();
  const pedidos = usePedidos();
  useTitle({ ...abrirProduto, ...pedidos });
  return (
    <>
    <GlobalStyle />
    <Produto {...abrirProduto} {...pedidos} />
    <Navbar />
    <Pedido {...pedidos} {...abrirProduto} />
    <Banner />
    <Menu {...abrirProduto} />
    </>
  );
}

export default App;
