using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            ViewBag.Produtos = produtos;

            return View();
        }

        //Nova action chamada form
        public ActionResult Form() {
            
            //lista de categoria
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();
            ViewBag.Categorias = categorias;

            return View();
        }

        //metodo adiciona
        // recebe como argumento o campo que quer receber
        [HttpPost]
        public ActionResult Adiciona(Produto produto) {

            //Produto produto = new Produto()
            //{
            //    Nome = nome,
            //    Preco = preco,
            //    Descricao = descricao,
            //    Quantidade = quantidade,
            //    CategoriaId = categoriaId
            //};

            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(produto);


            //return View(); manda pra view de sucesso
            // manda pra lista
            return RedirectToAction("Index", "Produto");
        }
    }
}