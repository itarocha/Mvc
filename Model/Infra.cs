/*
 * Criado por SharpDevelop.
 * Usuário: itamar.junior
 * Data: 30/04/2014
 * Hora: 16:12
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mvc.Model
{
	/// <summary>
	/// Description of Infra.
	/// </summary>
	public class Infra
	{
		public int Id {get; set;}
		public String Descricao {get; set;}
		public IList<Equipamento> Lista {get; set;}
	}
}
