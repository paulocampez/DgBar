import React from 'react';
import {
  getAllItens,
  getAllProdutos
} from "./ProdutoService";
const axios = require('axios');

export function formatPrice(valor) {
    return valor.toLocaleString("pt-BR", {
      style: "currency",
      currency: "BRL"
    });
  }


// async function testee(){
//   return await axios.get('https://localhost:5001/api/Produto/all').then(res=>res.data);

// }


//    export const produtosItensFoo =  getAllProdutos()
//    .then(foo => {
//      const produ = foo.data;
//    }).finally(() => {
//      console.log("i should go second");
//  });
  
  // export const paulo = async(req, res) => {testee}

//  export const produtosItens = [
//   {
//     img: "/img/coca.jpg",
//     descricao: "Veggie Pizza",
//     tip: "Pizza",
//     valor: 2
//   },
//   {
//     img: "/img/coca.jpg",
//     descricao: "Veggie Pizza",
//     tip: "Pizza",
//     valor: 2
//   }, {
//     img: "/img/coca.jpg",
//     descricao: "Veggie Pizza",
//     tip: "Pizza",
//     valor: 2
//   }, {
//     img: "/img/coca.jpg",
//     descricao: "Veggie Pizza",
//     tip: "Pizza",
//     valor: 2
//   }, {
//     img: "/img/coca.jpg",
//     descricao: "Veggie Pizza",
//     tip: "Pizza",
//     valor: 2
//   }, {
//     img: "/img/coca.jpg",
//     descricao: "Veggie Pizza",
//     tip: "Pizza",
//     valor: 2
//   },

// ];

export const getProdutosEriquim = async() => {
  return getAllProdutos();
  
}

  export const produtos = 
  //  getProdutosEriquim().then(res => console.log("" + res.data));
  getProdutosEriquim().then(res => res.data.reduce((res, produtos) => {
    if (!res[produtos.tipo]) {
      res[produtos.tipo] = [];
    }
    res[produtos.tipo].push(produtos);
    return res;
  }, {}));

  // .reduce((res, produtos) => {

  //     if (!res[produtos.tipo]) {
  //       res[produtos.tipo] = [];
  //     }
  //     res[produtos.tipo].push(produtos);
  //     return res;
  //   }, {});


  
  