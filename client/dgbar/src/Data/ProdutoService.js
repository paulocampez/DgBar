import axios from "axios";

export const getAllProdutos = () => {
    axios.defaults.baseURL = 'http://localhost';
    axios.defaults.headers.post['Content-Type'] ='application/json;charset=utf-8';
    axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
    //return axios.get("https://jsonplaceholder.typicode.com/todos/");
   return axios.get("https://localhost:5001/api/Produto/all");
};

export const registrarItem = ProdutosItens => {
  return axios.post("https://localhost:5001/api/Comanda/buyItem", ProdutosItens);
};