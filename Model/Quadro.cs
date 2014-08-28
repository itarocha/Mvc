using System;
using System.Collections;
using System.Collections.Generic;

namespace Mvc.Model
{
	/// <summary>
	/// Description of Quadro.
	/// </summary>
	public class Quadro
	{
		//public List<String> Cabecalho {get; set;}
		public List<Coluna> Colunas {get; set;}
		public List<Faixa> Faixas {get; set;}
		
		
		
		//public List<String> Horarios {get; set;}
		public List<Celula> Celulas = new List<Celula>();
			
		public Quadro(){
			
			//Cabecalho = new List<String>{"Aleph", "Beth", "Guimel", "Daleth", "Vav", "Toth", "Zain"};
			//Horarios = new List<String>{"001-005","006-010", "011-015", "016-020"};
			Colunas = new List<Coluna>{
				new Coluna(){Id = 1, Descricao="Aleph", Selecionavel=false},
				new Coluna(){Id = 2, Descricao="Beth", Selecionavel=true},
				new Coluna(){Id = 3, Descricao="Guimel", Selecionavel=true},
				new Coluna(){Id = 4, Descricao="Daleth", Selecionavel=true},
				new Coluna(){Id = 5, Descricao="He", Selecionavel=true},
				new Coluna(){Id = 6, Descricao="Vav", Selecionavel=false},
				new Coluna(){Id = 7, Descricao="Zayin", Selecionavel=true},
			};
			Faixas = new List<Faixa>{
				new Faixa(){Id = 1, ValorIni="001", ValorFim = "005"},
				new Faixa(){Id = 2, ValorIni="006", ValorFim = "010"},
				new Faixa(){Id = 3, ValorIni="011", ValorFim = "015"},
				new Faixa(){Id = 4, ValorIni="016", ValorFim = "020"},
				new Faixa(){Id = 5, ValorIni="021", ValorFim = "025"},
			};
		}
	}
	
	public class Coluna
	{
		public int Id {get; set;}
		public string Descricao {get; set;}
		public bool Selecionavel {get; set;}
	}
	
	public class Faixa
	{
		public int Id {get; set;}
		public string ValorIni {get; set;}
		public string ValorFim {get; set;}

		
		public override string ToString(){
			return String.Format("{0} - {1}",this.ValorIni,this.ValorFim);
		}
	}
	
	public class Celula
	{
		public int CabecalhoId {get; set;}
		public int HorarioId {get; set;}
		public string Nome {get; set;}
	}
	
	
	public class RetornoQuadro
	{
		public int PessoaId {get; set;}
		public int[] horarios {get;set;}
	}
	
}
