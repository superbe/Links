using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Links.WWW.Models
{
	/// <summary>
	/// Элемент дерева каталога.
	/// </summary>
	public class Link
	{
		/// <summary>
		/// Идентификатор ссылки.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Родительская ссылка.
		/// </summary>
		public int ParentId { get; set; }

		/// <summary>
		/// Наименование ссылки.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// URL адрес ссылки.
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Дочерние элементы.
		/// </summary>
		public Link[] Children { get; set; }
	}
}