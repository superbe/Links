using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Links.WWW.Models
{
	/// <summary>
	/// Хранилище данных ссылок.
	/// </summary>
	public class LinksContext
	{
		private string _filename = "Data/Links.xml";
		private LinkList _link;

		/// <summary>
		/// Ссылки.
		/// </summary>
		public LinkList Link { get => _link; }

		/// <summary>
		/// Конструктор.
		/// </summary>
		public LinksContext()
		{
			if (File.Exists(_filename))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(LinkList));
				using (Stream reader = new FileStream(_filename, FileMode.Open))
				{
					_link = (LinkList)serializer.Deserialize(reader);
				}
			}
			else
			{
				_link = new LinkList();
			}
		}

		/// <summary>
		/// Сохранить изменения.
		/// </summary>
		internal void SaveChanges()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(LinkList));
			using (Stream fs = new FileStream(_filename, FileMode.Create))
			{
				XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
				serializer.Serialize(writer, _link);
				writer.Close();
			}
		}

		/// <summary>
		/// Обновить текущую ссылку.
		/// </summary>
		/// <param name="value">Текущая ссылка.</param>
		internal void Entry(Link value)
		{
			Link result = _link.Find(value.Id);
			result.Name = value.Name;
			result.Url = value.Url;
			if (result.ParentId != value.ParentId)
			{
				Link parent = _link.Find(result.ParentId);
				if (parent != null)
					parent.Children.Remove(result);

				Link newParent = _link.Find(value.ParentId);
				if (newParent != null)
					newParent.Children.Add(result);
				else
					_link.Add(result);

				result.ParentId = value.ParentId;
			}
		}

		/// <summary>
		/// Добавить новую ссылку.
		/// </summary>
		/// <param name="value">Новая ссылка.</param>
		internal void Add(Link value)
		{
			value.Id = _link.GetMaxId() + 1;
			Link result = _link.Find(value.ParentId);
			if (result != null)
				result.Children.Add(value);
			else
				_link.Add(value);
		}

		/// <summary>
		/// Удалить ссылку.
		/// </summary>
		/// <param name="value">Удаляемая ссылка.</param>
		internal void Remove(Link value)
		{
			Link parent = _link.Find(value.ParentId);
			if (parent == null)
				_link.Remove(value);
			else
				parent.Children.Remove(value);
		}
	}
}