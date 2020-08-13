import React, {useState} from 'react';
import logo from './logo.svg';
import { Navbar } from "./Navbar/Navbar";
import { GlobalStyle } from "./Styles/GlobalStyle";
import './App.css';
import { Banner } from "./Banner/Banner";
import { BotaoConfirma, Produto } from "./Produto/Produto";
import { BotaoReset, Checkout } from "./Checkout/Checkout";
import { Pedido } from "./Pedido/Pedido";
import { useAbrirProduto } from "./Hooks/useAbrirProduto";
import { useAbrirCheckout } from "./Hooks/useAbrirCheckout";
import { usePedidos } from "./Hooks/usePedidos";
import { useTitle } from "./Hooks/useTitle";
import { useComanda } from "./Hooks/useComanda";
import { Menu } from "./Menu/Menu";
import axios from "axios";

function App() {
  const abrirProduto = useAbrirProduto();
  const abrirCheckout = useAbrirCheckout();
  const pedidos = usePedidos();
  const [numeroComanda, setNumeroComanda] = useState(0);
  const comandas = useComanda();
  useTitle({ ...abrirProduto, ...pedidos });
  return (
    <>
    <GlobalStyle />
    <Produto {...abrirProduto} {...pedidos} {...comandas}/>
    <Checkout {...abrirCheckout} {...pedidos} {...comandas}/>
    {/* <Produto {...abrirProduto} {...pedidos} {...comandas}/> */}
    <Navbar />
    <Pedido {...pedidos} {...abrirProduto} {...comandas} />
    <Banner />
    <BotaoConfirma {...comandas} onClick={() => {
      if(numeroComanda == 0){
      axios({
        headers: { 'Content-Type': 'application/json'},
        url: 'http://localhost:5001/api/Comanda/AbrirComanda',
        method: 'post'
      })
      .then(function (response) {
        
        comandas.setNumeroComanda(response.data.numeroComanda);
        comandas.numeroComanda = response.data.numeroComanda;
        setNumeroComanda(response.data.numeroComanda)
      })
      .catch(function (error) {
          console.log(error);
      });
    }
    else{
      axios({
        headers: { 'Content-Type': 'application/json'},
        url: 'http://localhost:5001/api/Comanda/FecharComanda/',
        method: 'post',
        data: numeroComanda
      })
      .then(function (response) {
        console.log(response)
        abrirCheckout.setAbrirCheckout(response);
      })
      .catch(function (error) {
          console.log(error);
      });
    }
    }}>{numeroComanda == 0 ? `Abrir Comanda` : `Fechar Comanda (`+numeroComanda+ `)`}  </BotaoConfirma>
    <BotaoReset onClick={() => {
      axios({
        headers: { 'Content-Type': 'application/json'},
        url: 'http://localhost:5001/api/Comanda/ResetarComanda/',
        method: 'post',
        data: numeroComanda
      })
      .then(function (response) {
        alert("Comanda Resetada")
      })
      .catch(function (error) {
          console.log(error);
      });
    }
      
    }> {"Resetar Comanda"} </BotaoReset>
    <Menu {...abrirProduto} {...comandas}/>
    
    </>
  );
}

export default App;
