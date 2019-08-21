using System;

namespace Links.WWW.Models
{
	/// <summary>
	/// Элемент дерева каталога (ссылка).
	/// </summary>
	[Serializable]
	public class Link
	{
		/// <summary>
		/// Идентификатор ссылки.
		/// </summary>
		public int Id { get; set; }

		internal Link Find(int id)
		{
			return Children.Find(id);
		}

		/// <summary>
		/// Родительский идентификатор.
		/// </summary>
		public int ParentId { get; set; }

		internal int GetMaxId()
		{
			if (Children.Count == 0) return Id;
			int id = Children.GetMaxId();
			return id > Id ? id : Id;
		}

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
		public LinkList Children { get; set; }

		public Link()
		{
			Children = new LinkList();
		}
	}
}