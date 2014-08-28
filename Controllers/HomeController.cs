/*
 * Created by SharpDevelop.
 * User: itamar.junior
 * Date: 25/02/2014
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;

using Mvc.Model;

namespace Mvc.Controllers
{
	public class HomeController : Controller
	{
		
		public HomeController(){
		}
		
		public ActionResult Index()
		{
			int mesAtual = DateTime.Today.Month;
			int anoAtual = DateTime.Today.Year;
			
			Session["mesAtual"] = mesAtual;
			Session["anoAtual"] = anoAtual;


			List<Item> itens = BuildItens();
			ViewData["ListaItens"] = itens;

			Pessoa p = new Pessoa(){Nome = "Itamar"};
			p.Lista = new int[]{10,20,30};
			ViewData["Escolhidos"] = string.Join("-", p.Lista);

			return View(p);
		}

		[HttpPost]
		public ActionResult Index(Pessoa p)
		{
			int[] escolhidos = p.Lista;
			ViewData["Escolhidos"] = (escolhidos == null) ? "" : string.Join("-", escolhidos);
			List<Item> itens = BuildItens();
			ViewData["ListaItens"] = itens;
			p.Lista = (escolhidos != null) ? escolhidos : new int[]{};
			return View(p);
		}
		
		
		public ActionResult Contact()
		{
			List<Item> itens = BuildItens();
			List<Item> comprados = BuildComprados();
			ViewData["ListaItens"] = itens;
			return View(comprados);
		}

		[HttpPost]
		public ActionResult Contact(int[] lista)
		{
			var ab = lista;
			List<Item> itens = BuildItens();
			List<Item> comprados = BuildComprados();
			ViewData["ListaItens"] = itens;
			return View(comprados);
		}

		public ActionResult Equipamentos()
		{
			Infra model = new Infra(){ Id = 10, Descricao = "Itens de Infraestrutura"};
			List<Equipamento> lista = BuildEquipamentos();
			model.Lista = lista;
			return View(lista);
		}
		
		[ActionName("Equipamentos")]
		[HttpPost]
		public ActionResult EquipamentosPost(IList<Mvc.Model.Equipamento> lista)
		{
			foreach (Equipamento e in lista) {
				e.Quantidade = e.Quantidade * 2 + 1;
			}
			return View(lista);
		}		
		
		public ActionResult Outro()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Outro(FormCollection formCollection)
		{
			foreach (string k in formCollection)
    		{
        		ViewData[k] = formCollection[k];
    		}
		
			/*			
			foreach (var key in formCollection.AllKeys)
			{
				var value = formCollection[key];
			      // etc.
			}
			
			foreach (var key in formCollection.Keys)
			{
				var value = formCollection[key.ToString()];
			    // etc.
			}		
			*/    
		    
		    return View();
		}		

		private List<Equipamento> BuildEquipamentos(){
			List<Equipamento> itens = new List<Equipamento>();
			itens.Add(new Equipamento() { Id = 10, Descricao = "Computador", Quantidade = 12 });
			itens.Add(new Equipamento() { Id = 20, Descricao = "DVD", Quantidade = 4 });
			itens.Add(new Equipamento() { Id = 30, Descricao = "Televisor", Quantidade = 6 });
			itens.Add(new Equipamento() { Id = 40, Descricao = "Telefone", Quantidade = 7 });
			return itens;
		}

		private List<Item> BuildItens(){
			List<Item> itens = new List<Item>();
			itens.Add(new Item() { Id = 10, Descricao = "Arroz agulinha" });
			itens.Add(new Item() { Id = 20, Descricao = "Desinfetante" });
			itens.Add(new Item() { Id = 30, Descricao = "Detergente" });
			itens.Add(new Item() { Id = 40, Descricao = "Extrato de tomate" });
			itens.Add(new Item() { Id = 50, Descricao = "Feijão carioquinha" });
			itens.Add(new Item() { Id = 60, Descricao = "Óleo de soja" });
			return itens;
		}
		
		private List<Item> BuildComprados(){
			List<Item> itens = new List<Item>();
			//itens.Add(new Item() { Id = 40, Descricao = "Arroz agulinha" });
			//itens.Add(new Item() { Id = 10, Descricao = "Desinfetante" });
			itens.Add(new Item() { Id = 50, Descricao = "Detergente" });
			itens.Add(new Item() { Id = 20, Descricao = "Extrato de tomate" });
			//itens.Add(new Item() { Id = 10, Descricao = "Feijão carioquinha" });
			itens.Add(new Item() { Id = 30, Descricao = "Óleo de soja" });
			return itens;
		}
		
		private List<Item> BuildCompradosAll(){
			List<Item> itens = new List<Item>();
			itens.Add(new Item() { Id = 40, Descricao = "Arroz agulinha" });
			itens.Add(new Item() { Id = 10, Descricao = "Desinfetante" });
			itens.Add(new Item() { Id = 50, Descricao = "Detergente" });
			itens.Add(new Item() { Id = 20, Descricao = "Extrato de tomate" });
			itens.Add(new Item() { Id = 10, Descricao = "Feijão carioquinha" });
			itens.Add(new Item() { Id = 30, Descricao = "Óleo de soja" });
			return itens;
		}
		
		//[AcceptVerbs(HttpVerbs.Post, HttpVerbs.Get)]
		public ActionResult GetFooList(int FooId = 0)
		{
		    List<Foo> fooList = new List<Foo>();
		    fooList.Add(new Foo { FooId = 1, Name = FooId + " One" } );
		    fooList.Add(new Foo { FooId = 1, Name = FooId + " Two" } );
		    fooList.Add(new Foo { FooId = 2, Name = FooId + " Three" });
		    fooList.Add(new Foo { FooId = 2, Name = FooId + " Four" });
		    //return Json(fooList.Where(foo => foo.FooId == FooId).ToList(),JsonRequestBehavior.AllowGet);
		    return Json(fooList,JsonRequestBehavior.AllowGet);
		}
	
		
		[HttpPost]
		[ActionName("horarios")]
		public ActionResult HorariosViaPost(Object o, String data){
			var result = true;
			return Content(result ? "OK" : String.Empty);
		}
		
		// Para selecionar
		public ActionResult TabelaDinamica(){
			Quadro q = new Quadro();
			
			List<Celula> celulas = new List<Celula>();
			celulas.Add(new Celula(){CabecalhoId = 2, HorarioId = 2, Nome = "Raimundo22"});
			celulas.Add(new Celula(){CabecalhoId = 2, HorarioId = 3, Nome = "Raimundo22"});
			celulas.Add(new Celula(){CabecalhoId = 3, HorarioId = 3, Nome = "Nonato33"});
			celulas.Add(new Celula(){CabecalhoId = 1, HorarioId = 1, Nome = "Jowanna11"});
			
			q.Celulas = celulas; 
			
			ViewBag.Quadro = q;
			return View();
		}
		

		
		
		
		// Quadro
		public ActionResult Quadro(){
			Quadro q = new Quadro();
			
			List<Celula> celulas = new List<Celula>();
			celulas.Add(new Celula(){CabecalhoId = 2, HorarioId = 2, Nome = "Academia"});
			celulas.Add(new Celula(){CabecalhoId = 2, HorarioId = 3, Nome = "Musculação"});
			celulas.Add(new Celula(){CabecalhoId = 3, HorarioId = 3, Nome = "Academia"});
			celulas.Add(new Celula(){CabecalhoId = 1, HorarioId = 1, Nome = "Ginástica"});
			celulas.Add(new Celula(){CabecalhoId = 1, HorarioId = 4, Nome = "Dança"});
			
			q.Celulas = celulas; 
			
			ViewBag.Linhas = 5;
			ViewBag.Colunas = 8;
			ViewBag.Cabecalho = new string[]{"a","b","c","d","e"};
			
			ViewBag.Quadro = q;
			return View(q);
		}
		
		/*
		XP
		Relacionamento humano não se aprende em uma semana. Certificação não é tudo
		Desenvolver software tá mais ligado a entender o ser humano
		Mostrar resultado mais cedo!!!! Toda semana!
		Empreendedismo: Acreditar em uma ideia, fazer acontecer...
		Entender como vender uma ideia: Influenciar pessoas a comprar uma ideia, um objetivo, uma causa
		Fazer o sw representa 1% do esforço. 99% do esforço está na venda

/*		
		[HttpPost]
		[ActionName("Quadro")]
		public ActionResult QuadroConfirmed(int[] horarios){
			var x = horarios;
			
			for (int i = 0; i <= horarios.Length -1; i++){
				Console.WriteLine(horarios[i]);
			}
			return Redirect("/Home/Quadro");
		}
*/
		[HttpPost]
		[ActionName("Quadro")]
		public ActionResult QuadroRetornoConfirmed(RetornoQuadro r){
			var x = r.horarios;
			
			for (int i = 0; i <= r.horarios.Length -1; i++){
				Console.WriteLine(r.horarios[i]);
			}
			return Redirect("/Home/Quadro");
		}
		
		
		
		
		
		
		

		public JsonResult Get(Int32 id)
	    {
		    List<Foo> fooList = new List<Foo>();
		    fooList.Add(new Foo { FooId = 1, Name = id + " One" } );
		    fooList.Add(new Foo { FooId = 1, Name = id + " Two" } );
		    fooList.Add(new Foo { FooId = 2, Name = id + " Three" });
		    fooList.Add(new Foo { FooId = 2, Name = id + " Four" });
		    //return Json(fooList.Where(foo => foo.FooId == FooId).ToList(),JsonRequestBehavior.AllowGet);
		    return Json(fooList,JsonRequestBehavior.AllowGet);
	    }		
		
		// Para selecionar
		public ActionResult MatrizSelecionar(){
			
			List<string> cabecalho = new List<string>{"DU","DU-HAST","DU-HAST-MICH"};
			
			ViewBag.Cabecalho = cabecalho;
			//ViewData["cabecalho"] = cabecalho;
			
			//ViewData["modalidadeId"] = modalidadeId;
			//ViewData["etapaId"] = etapaId;
			return View();
		}

		// Já selecionado
		public ActionResult Matriz(int modalidadeId, int etapaId){
			ViewData["modalidadeId"] = modalidadeId;
			ViewData["etapaId"] = etapaId;
			
			// Se não existir, insere
			
			MatrizVO model = new MatrizVO(){ ModalidadeId = modalidadeId, EtapaId = etapaId };
			model.Id = new Random().Next(120);
			return View(model);
		}
		
		// Já selecionado
		[HttpPost, ActionName("Matriz")]
		public ActionResult Matriz(MatrizVO model){
			// Se não existir, insere, se existir, atualiza
			
			//int id = new Random().Next(5000);
			//model.Id = id; 
			
			// Na verdade deve enviar para MatrizDisciplina/id/
			return Redirect(String.Format("/MatrizDisciplina/{0}",model.Id));
		}


		// Já selecionado
		public ActionResult MatrizDisciplina(int matrizId, int disciplinaId = 0){
			//ViewData["modalidadeId"] = modalidadeId;
			//ViewData["etapaId"] = etapaId;
			
			// Se não existir, insere
			
			if (disciplinaId == 0){
				ViewBag.Title = "Incluindo Disc on Matriz";
			} else {
				ViewBag.Title = "Editando Disc on Matriz";
			}
			
			MatrizDisciplinaVO model = new MatrizDisciplinaVO(){
				MatrizId = matrizId,
				DisciplinaId = disciplinaId
			};
			return View(model);
		}
		
		// Já selecionado
		[HttpPost, ActionName("MatrizDisciplina")]
		public ActionResult Matriz(MatrizDisciplinaVO model){
			// Se não existir, insere, se existir, atualiza
			
			int id = new Random().Next(5000);
			model.Id = id; 
			
			// Na verdade deve enviar para MatrizDisciplina/id/
			return Redirect(String.Format("/MatrizDisciplina/{0}",model.MatrizId));
		}
		
		
		public ActionResult Calendario(int id = 0){
			//id = ((id <= 0) && (id >= 13)) ? 8 : id;
			
			TheCalendario calendario = new TheCalendario(2014,id);
			
			return View(calendario);
		}
		
		[HttpPost]
        public JsonResult CalendarioPost(EnvioCalendario data)
        {
        	
        	int id = /*data.NumeroDia + */data.Mes;
        	
		    List<Estilo> fooList = new List<Estilo>();
		    
		    fooList.Add(new Estilo { Dia = 3, Bg = "#f0f", Fg="#000" } );
		    fooList.Add(new Estilo { Dia = 8, Bg = "#f00", Fg="#fff" } );
		    fooList.Add(new Estilo { Dia = 10, Bg = "#ff0", Fg="#000" } );
		    fooList.Add(new Estilo { Dia = 17, Bg = "#f0f", Fg="#000" } );
		    fooList.Add(new Estilo { Dia = 20, Bg = "#f0f", Fg="#000" } );
		    fooList.Add(new Estilo { Dia = 22, Bg = "#0ff", Fg="#000" } );
		    fooList.Add(new Estilo { Dia = 23, Bg = "#f00", Fg="#fff" } );
		    fooList.Add(new Estilo { Dia = 28, Bg = "#ff0", Fg="#000" } );

		    //return Json(fooList.Where(foo => foo.FooId == FooId).ToList(),JsonRequestBehavior.AllowGet);
		    
		    return Json(fooList,JsonRequestBehavior.AllowGet);
        }		
        
        public JsonResult GetCores(){
        	
        	List<HtmlColors> lst = new List<HtmlColors>();
 
        	
			// Monocromático
			lst.Add(new HtmlColors { Id = 001, Bg ="#ffffff", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 002, Bg ="#cccccc", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 003, Bg ="#c0c0c0", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 004, Bg ="#999999", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 005, Bg ="#666666", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 006, Bg ="#333333", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 007, Bg ="#000000", Fg="#fff" });
  
	  
			// Vermelho	  
        	lst.Add(new HtmlColors { Id = 008, Bg ="#ffcccc", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 009, Bg ="#ff6666", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 010, Bg ="#ff0000", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 011, Bg ="#cc0000", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 012, Bg ="#990000", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 013, Bg ="#660000", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 014, Bg ="#330000", Fg="#fff" });
	  
	  
			// Laranja	  
        	lst.Add(new HtmlColors { Id = 015, Bg ="#ffcc99", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 016, Bg ="#ffcc33", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 017, Bg ="#ff9900", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 018, Bg ="#ff6600", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 019, Bg ="#cc6600", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 020, Bg ="#993300", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 021, Bg ="#663300", Fg="#fff" });
	  
	  
			// Amarelos	  
        	lst.Add(new HtmlColors { Id = 022, Bg ="#ffffcc", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 023, Bg ="#ffff99", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 024, Bg ="#ffff00", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 025, Bg ="#ffcc00", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 026, Bg ="#999900", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 027, Bg ="#666600", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 028, Bg ="#333300", Fg="#fff" });


			// Verdes
        	lst.Add(new HtmlColors { Id = 029, Bg ="#99ff99", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 030, Bg ="#66ff99", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 031, Bg ="#33ff33", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 032, Bg ="#00cc00", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 033, Bg ="#009900", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 034, Bg ="#006600", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 035, Bg ="#003300", Fg="#fff" });
	  
	  
			// Azuis	  
        	lst.Add(new HtmlColors { Id = 036, Bg ="#ccffff", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 037, Bg ="#66ffff", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 038, Bg ="#33ccff", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 039, Bg ="#3366ff", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 040, Bg ="#3333ff", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 041, Bg ="#000099", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 042, Bg ="#000066", Fg="#fff" });
	  
	  
			// Magentas	  
        	lst.Add(new HtmlColors { Id = 043, Bg ="#ffccff", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 044, Bg ="#ff99ff", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 045, Bg ="#cc66cc", Fg="#000" });
        	lst.Add(new HtmlColors { Id = 046, Bg ="#cc33cc", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 047, Bg ="#993366", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 048, Bg ="#663366", Fg="#fff" });
        	lst.Add(new HtmlColors { Id = 049, Bg ="#330033", Fg="#fff" });
        	
        	return Json(lst,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetFiguras(){
        	
        	List<Figura> lst = new List<Figura>();
			        		
			lst.Add(new Figura { Descricao = "glyphicon-asterisk" });
			lst.Add(new Figura { Descricao = "glyphicon-plus" });
			lst.Add(new Figura { Descricao = "glyphicon-euro" });
			lst.Add(new Figura { Descricao = "glyphicon-minus" });
			lst.Add(new Figura { Descricao = "glyphicon-cloud" });
			lst.Add(new Figura { Descricao = "glyphicon-envelope" });
			lst.Add(new Figura { Descricao = "glyphicon-pencil" });
			lst.Add(new Figura { Descricao = "glyphicon-glass" });
			lst.Add(new Figura { Descricao = "glyphicon-music" });
			lst.Add(new Figura { Descricao = "glyphicon-search" });
			lst.Add(new Figura { Descricao = "glyphicon-heart" });
			lst.Add(new Figura { Descricao = "glyphicon-star" });
			lst.Add(new Figura { Descricao = "glyphicon-star-empty" });
			lst.Add(new Figura { Descricao = "glyphicon-user" });
			lst.Add(new Figura { Descricao = "glyphicon-film" });
			lst.Add(new Figura { Descricao = "glyphicon-th-large" });
			lst.Add(new Figura { Descricao = "glyphicon-th" });
			lst.Add(new Figura { Descricao = "glyphicon-th-list" });
			lst.Add(new Figura { Descricao = "glyphicon-ok" });
			lst.Add(new Figura { Descricao = "glyphicon-remove" });
			lst.Add(new Figura { Descricao = "glyphicon-zoom-in" });
			lst.Add(new Figura { Descricao = "glyphicon-zoom-out" });
			lst.Add(new Figura { Descricao = "glyphicon-off" });
			lst.Add(new Figura { Descricao = "glyphicon-signal" });
			lst.Add(new Figura { Descricao = "glyphicon-cog" });
			lst.Add(new Figura { Descricao = "glyphicon-trash" });
			lst.Add(new Figura { Descricao = "glyphicon-home" });
			lst.Add(new Figura { Descricao = "glyphicon-file" });
			lst.Add(new Figura { Descricao = "glyphicon-time" });
			lst.Add(new Figura { Descricao = "glyphicon-road" });
			lst.Add(new Figura { Descricao = "glyphicon-download-alt" });
			lst.Add(new Figura { Descricao = "glyphicon-download" });
			lst.Add(new Figura { Descricao = "glyphicon-upload" });
			lst.Add(new Figura { Descricao = "glyphicon-inbox" });
			lst.Add(new Figura { Descricao = "glyphicon-play-circle" });
			lst.Add(new Figura { Descricao = "glyphicon-repeat" });
			lst.Add(new Figura { Descricao = "glyphicon-refresh" });
			lst.Add(new Figura { Descricao = "glyphicon-list-alt" });
			lst.Add(new Figura { Descricao = "glyphicon-lock" });
			lst.Add(new Figura { Descricao = "glyphicon-flag" });
			lst.Add(new Figura { Descricao = "glyphicon-headphones" });
			lst.Add(new Figura { Descricao = "glyphicon-volume-off" });
			lst.Add(new Figura { Descricao = "glyphicon-volume-down" });
			lst.Add(new Figura { Descricao = "glyphicon-volume-up" });
			lst.Add(new Figura { Descricao = "glyphicon-qrcode" });
			lst.Add(new Figura { Descricao = "glyphicon-barcode" });
			lst.Add(new Figura { Descricao = "glyphicon-tag" });
			lst.Add(new Figura { Descricao = "glyphicon-tags" });
			lst.Add(new Figura { Descricao = "glyphicon-book" });
			lst.Add(new Figura { Descricao = "glyphicon-bookmark" });
			lst.Add(new Figura { Descricao = "glyphicon-print" });
			lst.Add(new Figura { Descricao = "glyphicon-camera" });
			lst.Add(new Figura { Descricao = "glyphicon-font" });
			lst.Add(new Figura { Descricao = "glyphicon-bold" });
			lst.Add(new Figura { Descricao = "glyphicon-italic" });
			lst.Add(new Figura { Descricao = "glyphicon-text-height" });
			lst.Add(new Figura { Descricao = "glyphicon-text-width" });
			lst.Add(new Figura { Descricao = "glyphicon-align-left" });
			lst.Add(new Figura { Descricao = "glyphicon-align-center" });
			lst.Add(new Figura { Descricao = "glyphicon-align-right" });
			lst.Add(new Figura { Descricao = "glyphicon-align-justify" });
			lst.Add(new Figura { Descricao = "glyphicon-list" });
			lst.Add(new Figura { Descricao = "glyphicon-indent-left" });
			lst.Add(new Figura { Descricao = "glyphicon-indent-right" });
			lst.Add(new Figura { Descricao = "glyphicon-facetime-video" });
			lst.Add(new Figura { Descricao = "glyphicon-picture" });
			lst.Add(new Figura { Descricao = "glyphicon-map-marker" });
			lst.Add(new Figura { Descricao = "glyphicon-adjust" });
			lst.Add(new Figura { Descricao = "glyphicon-tint" });
			lst.Add(new Figura { Descricao = "glyphicon-edit" });
			lst.Add(new Figura { Descricao = "glyphicon-share" });
			lst.Add(new Figura { Descricao = "glyphicon-check" });
			lst.Add(new Figura { Descricao = "glyphicon-move" });
			lst.Add(new Figura { Descricao = "glyphicon-step-backward" });
			lst.Add(new Figura { Descricao = "glyphicon-fast-backward" });
			lst.Add(new Figura { Descricao = "glyphicon-backward" });
			lst.Add(new Figura { Descricao = "glyphicon-play" });
			lst.Add(new Figura { Descricao = "glyphicon-pause" });
			lst.Add(new Figura { Descricao = "glyphicon-stop" });
			lst.Add(new Figura { Descricao = "glyphicon-forward" });
			lst.Add(new Figura { Descricao = "glyphicon-fast-forward" });
			lst.Add(new Figura { Descricao = "glyphicon-step-forward" });
			lst.Add(new Figura { Descricao = "glyphicon-eject" });
			lst.Add(new Figura { Descricao = "glyphicon-chevron-left" });
			lst.Add(new Figura { Descricao = "glyphicon-chevron-right" });
			lst.Add(new Figura { Descricao = "glyphicon-plus-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-minus-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-remove-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-ok-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-question-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-info-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-screenshot" });
			lst.Add(new Figura { Descricao = "glyphicon-remove-circle" });
			lst.Add(new Figura { Descricao = "glyphicon-ok-circle" });
			lst.Add(new Figura { Descricao = "glyphicon-ban-circle" });
			lst.Add(new Figura { Descricao = "glyphicon-arrow-left" });
			lst.Add(new Figura { Descricao = "glyphicon-arrow-right" });
			lst.Add(new Figura { Descricao = "glyphicon-arrow-up" });
			lst.Add(new Figura { Descricao = "glyphicon-arrow-down" });
			lst.Add(new Figura { Descricao = "glyphicon-share-alt" });
			lst.Add(new Figura { Descricao = "glyphicon-resize-full" });
			lst.Add(new Figura { Descricao = "glyphicon-resize-small" });
			lst.Add(new Figura { Descricao = "glyphicon-exclamation-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-gift" });
			lst.Add(new Figura { Descricao = "glyphicon-leaf" });
			lst.Add(new Figura { Descricao = "glyphicon-fire" });
			lst.Add(new Figura { Descricao = "glyphicon-eye-open" });
			lst.Add(new Figura { Descricao = "glyphicon-eye-close" });
			lst.Add(new Figura { Descricao = "glyphicon-warning-sign" });
			lst.Add(new Figura { Descricao = "glyphicon-plane" });
			lst.Add(new Figura { Descricao = "glyphicon-calendar" });
			lst.Add(new Figura { Descricao = "glyphicon-random" });
			lst.Add(new Figura { Descricao = "glyphicon-comment" });
			lst.Add(new Figura { Descricao = "glyphicon-magnet" });
			lst.Add(new Figura { Descricao = "glyphicon-chevron-up" });
			lst.Add(new Figura { Descricao = "glyphicon-chevron-down" });
			lst.Add(new Figura { Descricao = "glyphicon-retweet" });
			lst.Add(new Figura { Descricao = "glyphicon-shopping-cart" });
			lst.Add(new Figura { Descricao = "glyphicon-folder-close" });
			lst.Add(new Figura { Descricao = "glyphicon-folder-open" });
			lst.Add(new Figura { Descricao = "glyphicon-resize-vertical" });
			lst.Add(new Figura { Descricao = "glyphicon-resize-horizontal" });
			lst.Add(new Figura { Descricao = "glyphicon-hdd" });
			lst.Add(new Figura { Descricao = "glyphicon-bullhorn" });
			lst.Add(new Figura { Descricao = "glyphicon-bell" });
			lst.Add(new Figura { Descricao = "glyphicon-certificate" });
			lst.Add(new Figura { Descricao = "glyphicon-thumbs-up" });
			lst.Add(new Figura { Descricao = "glyphicon-thumbs-down" });
			lst.Add(new Figura { Descricao = "glyphicon-hand-right" });
			lst.Add(new Figura { Descricao = "glyphicon-hand-left" });
			lst.Add(new Figura { Descricao = "glyphicon-hand-up" });
			lst.Add(new Figura { Descricao = "glyphicon-hand-down" });
			lst.Add(new Figura { Descricao = "glyphicon-circle-arrow-right" });
			lst.Add(new Figura { Descricao = "glyphicon-circle-arrow-left" });
			lst.Add(new Figura { Descricao = "glyphicon-circle-arrow-up" });
			lst.Add(new Figura { Descricao = "glyphicon-circle-arrow-down" });
			lst.Add(new Figura { Descricao = "glyphicon-globe" });
			lst.Add(new Figura { Descricao = "glyphicon-wrench" });
			lst.Add(new Figura { Descricao = "glyphicon-tasks" });
			lst.Add(new Figura { Descricao = "glyphicon-filter" });
			lst.Add(new Figura { Descricao = "glyphicon-briefcase" });
			lst.Add(new Figura { Descricao = "glyphicon-fullscreen" });
			lst.Add(new Figura { Descricao = "glyphicon-dashboard" });
			lst.Add(new Figura { Descricao = "glyphicon-paperclip" });
			lst.Add(new Figura { Descricao = "glyphicon-heart-empty" });
			lst.Add(new Figura { Descricao = "glyphicon-link" });
			lst.Add(new Figura { Descricao = "glyphicon-phone" });
			lst.Add(new Figura { Descricao = "glyphicon-pushpin" });
			lst.Add(new Figura { Descricao = "glyphicon-usd" });
			lst.Add(new Figura { Descricao = "glyphicon-gbp" });
			lst.Add(new Figura { Descricao = "glyphicon-sort" });
			lst.Add(new Figura { Descricao = "glyphicon-sort-by-alphabet" });
			lst.Add(new Figura { Descricao = "glyphicon-sort-by-alphabet-alt" });
			lst.Add(new Figura { Descricao = "glyphicon-sort-by-order" });
			lst.Add(new Figura { Descricao = "glyphicon-sort-by-order-alt" }); 
			lst.Add(new Figura { Descricao = "glyphicon-sort-by-attributes" });
			lst.Add(new Figura { Descricao = "glyphicon-sort-by-attributes-alt" });
			lst.Add(new Figura { Descricao = "glyphicon-unchecked" });
			lst.Add(new Figura { Descricao = "glyphicon-expand" });
			lst.Add(new Figura { Descricao = "glyphicon-collapse-down" });
			lst.Add(new Figura { Descricao = "glyphicon-collapse-up" });
			lst.Add(new Figura { Descricao = "glyphicon-log-in" });
			lst.Add(new Figura { Descricao = "glyphicon-flash" });
			lst.Add(new Figura { Descricao = "glyphicon-log-out" });
			lst.Add(new Figura { Descricao = "glyphicon-new-window" });
			lst.Add(new Figura { Descricao = "glyphicon-record" });
			lst.Add(new Figura { Descricao = "glyphicon-save" });
			lst.Add(new Figura { Descricao = "glyphicon-open" });
			lst.Add(new Figura { Descricao = "glyphicon-saved" });
			lst.Add(new Figura { Descricao = "glyphicon-import" });
			lst.Add(new Figura { Descricao = "glyphicon-export" });
			lst.Add(new Figura { Descricao = "glyphicon-send" });
			lst.Add(new Figura { Descricao = "glyphicon-floppy-disk" });
			lst.Add(new Figura { Descricao = "glyphicon-floppy-saved" });
			lst.Add(new Figura { Descricao = "glyphicon-floppy-remove" });
			lst.Add(new Figura { Descricao = "glyphicon-floppy-save" });
			lst.Add(new Figura { Descricao = "glyphicon-floppy-open" });
			lst.Add(new Figura { Descricao = "glyphicon-credit-card" });
			lst.Add(new Figura { Descricao = "glyphicon-transfer" });
			lst.Add(new Figura { Descricao = "glyphicon-cutlery" });
			lst.Add(new Figura { Descricao = "glyphicon-header" });
			lst.Add(new Figura { Descricao = "glyphicon-compressed" });
			lst.Add(new Figura { Descricao = "glyphicon-earphone" });
			lst.Add(new Figura { Descricao = "glyphicon-phone-alt" });
			lst.Add(new Figura { Descricao = "glyphicon-tower" });
			lst.Add(new Figura { Descricao = "glyphicon-stats" });
			lst.Add(new Figura { Descricao = "glyphicon-sd-video" });
			lst.Add(new Figura { Descricao = "glyphicon-hd-video" });
			lst.Add(new Figura { Descricao = "glyphicon-subtitles" });
			lst.Add(new Figura { Descricao = "glyphicon-sound-stereo" });
			lst.Add(new Figura { Descricao = "glyphicon-sound-dolby" });
			lst.Add(new Figura { Descricao = "glyphicon-sound-5-1" });
			lst.Add(new Figura { Descricao = "glyphicon-sound-6-1" });
			lst.Add(new Figura { Descricao = "glyphicon-sound-7-1" });
			lst.Add(new Figura { Descricao = "glyphicon-copyright-mark" });
			lst.Add(new Figura { Descricao = "glyphicon-registration-mark" });
			lst.Add(new Figura { Descricao = "glyphicon-cloud-download" });
			lst.Add(new Figura { Descricao = "glyphicon-cloud-upload" });
			lst.Add(new Figura { Descricao = "glyphicon-tree-conifer" });
			lst.Add(new Figura { Descricao = "glyphicon-tree-deciduous" });
			        		
        	return Json(lst,JsonRequestBehavior.AllowGet);
        }
	}
	
	public class Figura{
		public string Descricao { get; set; }
	}
	
	public class HtmlColors
	{
		public int Id { get; set; }
		public string Bg { get; set; }
		public string Fg { get; set; }
	}
	
	public class EnvioCalendario
	{
		public int Mes {get; set;}
		public int Dia { get; set; }
		public string Evento { get; set; }
	}

	public class Estilo
	{
		public int Dia { get; set; }
		public string Bg { get; set; }
		public string Fg { get; set; }
	}

	
	public class Foo
	{
    	public int FooId { get; set; }
    	public string Name { get; set; }
	}

}