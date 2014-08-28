/*
 * Criado por SharpDevelop.
 * Usuário: itamar.junior
 * Data: 01/07/2014
 * Hora: 15:07
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Mvc.Model
{
	/// <summary>
	/// Description of MatrizDisciplina.
	/// </summary>
	public class MatrizDisciplinaVO
	{
		public int Id {get; set;}
		public int MatrizId {get; set;}
		public int DisciplinaId {get; set;}
		
		public MatrizDisciplinaVO(){}
	}
}
