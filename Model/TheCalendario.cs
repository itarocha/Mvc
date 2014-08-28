/*
 * Criado por SharpDevelop.
 * Usuário: itamar.junior
 * Data: 19/08/2014
 * Hora: 15:23
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mvc.Model
{
	
	public class TheCalendario{
		
		private int ano;
		private int mes;
		private int anoAnterior;
		private int anoPosterior;
		private int mesAnterior;
		private int mesPosterior;

		private string[] meses = {"Janeiro","Fevereiro","Março","Abril","Maio","Junho","Julho","Agosto","Setembro","Outubro","Novembro","Dezembro"};
		
		
		private List<DataCalendario> listaDias = new List<DataCalendario>();
		
		public TheCalendario(int ano, int mes){
			this.mes = ((mes > 0) && (mes < 13)) ? mes : DateTime.Today.Month;
			this.ano = ano;
			this.anoAnterior = ano;
			this.anoPosterior = ano;
			
			this.mesAnterior = (this.Mes == 1) ? this.Mes : this.Mes - 1;
			this.mesPosterior = (this.Mes == 12) ? this.Mes : this.Mes + 1;
			
			this.listaDias = buildCalendario(this.Ano, this.Mes);
		}
		
		public int Ano {get{return this.ano;}}
		public int Mes {get{return this.mes;}}
		
		public string MesNome {
			get {
				if ((this.Mes >= 1) && (this.Mes <= 12)){
					return meses[this.Mes-1];
				} else {
					return "Indefinido";
				}
			}
		}
		
		public int AnoAnterior {get{return this.anoAnterior;}}
		public int MesAnterior {get{return this.mesAnterior;}}

		public int AnoPosterior {get{return this.anoPosterior;}}
		public int MesPosterior {get{return this.mesPosterior;}}
		
		public List<DataCalendario> ListaDias {
			get{ return this.listaDias; }
		}
		
		private List<DataCalendario> buildCalendario(int ano, int mes){
			List<DataCalendario> dias = new List<DataCalendario>();
			
			int primeiroDia = 1;
			DateTime dt = new DateTime(ano, mes, primeiroDia);
			int diaSemana = (int)dt.DayOfWeek;
			int diasNoMes = DateTime.DaysInMonth(ano, mes);
			int qtdLinear = diaSemana + diasNoMes -1;
			
			int qtdTotal = 6 - (qtdLinear % 7);
			qtdLinear += qtdTotal;

			int dia;				
			for(int i = 0; i <= qtdLinear; i++){
				DataCalendario d = new DataCalendario();
				d.Index = i;
				dia = i - diaSemana + 1;
				d.Dia = (dia >= 0) && (dia <= diasNoMes) ? dia :  0;
				d.Modulo = i % 7; 
				dias.Add(d);
			}
			//Console.WriteLine(dt);
			//Console.WriteLine("Dia da semana: {0}",diaSemana);
			//Console.WriteLine("Dias no mês: {0}",diasNoMes);
			//Console.WriteLine("Qtd: {0}",qtdLinear);
			//Console.WriteLine("Sobra: {0}",(qtdLinear + 1) % 7);
			return dias;		
		}
		
		
	}
	
	/// <summary>
	/// Description of DataCalendario.
	/// </summary>
	public class DataCalendario
	{
		public int Index {get; set;}
		public int Dia {get; set;}
		public int Modulo {get; set;}

		public DataCalendario()
		{
		}
	}
}
