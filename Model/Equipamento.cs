/*
 * Criado por SharpDevelop.
 * Usuário: itamar.junior
 * Data: 30/04/2014
 * Hora: 14:48
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Mvc.Model
{
	/// <summary>
	/// Description of Equipamento.
	/// </summary>
	public class Equipamento
	{
		public int Id {get; set;}
		public String Descricao {get; set;}
		public int Quantidade {get; set;}
	}
}

/*
public class Country 
{
	public Country()
	{
		Details = new CountryInfo();
	}
	public String Name { get; set; }
	public CountryInfo Details { get; set; }

}
public class CountryInfo 
{
public String Capital { get; set; }
public String Continent { get; set; }
}
*/