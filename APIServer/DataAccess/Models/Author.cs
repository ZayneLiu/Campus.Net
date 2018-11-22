namespace DataAccess.Models
{
	public class Author
	{
		public Author()
		{
		}

		public Author(string id)
		{
			Id = id;
		}

		public string Id { get; }

		public string Avatar
		{
			get => "avatar_url";
			set { }
		}

		public string Field;

		public string Url;
	}
}