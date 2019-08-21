using System.Collections.Generic;

namespace Links.WWW.Models
{
	/// <summary>
	/// Коллекция ссылок.
	/// </summary>
	public class LinkList : List<Link>
	{
		/// <summary>
		/// Найти ссылку по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор ссылки.</param>
		/// <returns>Ссылка.</returns>
		internal Link Find(int id)
		{
			foreach (Link item in this)
			{
				if (item.Id == id)
				{
					return item;
				}
				else
				{
					Link result = item.Find(id);
					if (result != null) return result;
				}
			}
			return null;
		}

		/// <summary>
		/// Найти максимальное значение идентификатора ссылки.
		/// </summary>
		/// <returns>Максимальное значение идентификатора ссылки.</returns>
		internal int GetMaxId()
		{
			int result = 0;
			foreach (Link item in this)
			{
				int id = item.GetMaxId();
				if (result < id) result = id;
			}
			return result;
		}
	}
}