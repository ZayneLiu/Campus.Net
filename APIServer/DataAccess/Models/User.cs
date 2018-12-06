#region

using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

#endregion

namespace DataAccess.Models
{
	/// <summary>
	///     User.
	/// </summary>
	public class User
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[BsonId]
		public ObjectId Id { get; set; }

		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[BsonElement("Username")]
		public string Username { get; set; }

		/// <summary>
		///     Gets or sets the scid.
		/// </summary>
		/// <value>The scid.</value>
		[BsonElement("SCID")]
		public string SCID { get; set; }

		/// <summary>
		///     Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		[BsonElement("Password")]
		public string Password { get; set; }

		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		[BsonElement("Email")]
		public string Email { get; set; }

		/// <summary>
		///     Gets or sets the tel.
		/// </summary>
		/// <value>The tel.</value>
		[BsonIgnore]
		public string Tel { get; set; }

		/// <summary>
		///     Gets or sets the real-name.
		/// </summary>
		/// <value>The real-name.</value>
		[BsonIgnore]
		public string RealName { get; set; }

		/// <summary>
		///     Gets or sets the gender.
		/// </summary>
		/// <value>The gender.</value>
		[BsonIgnore]
		public string Gender { get; set; }

		/// <summary>
		///     Gets or sets the birthday.
		/// </summary>
		/// <value>The birthday.</value>
		[BsonIgnore]
		public DateTime Birthday { get; set; }

		/// <summary>
		///     Gets or sets the biography.
		/// </summary>
		/// <value>The biography.</value>
		[BsonIgnore]
		public string Biography { get; set; }

		/// <summary>
		///     Gets or sets my involvement.
		/// </summary>
		/// <value>My involvement.</value>
		[BsonIgnore]
		public List<string> MyInvolvement { get; set; }

		/// <summary>
		///     Gets or sets my stars.
		/// </summary>
		/// <value>My stars.</value>
		[BsonIgnore]
		public List<string> MyStars { get; set; }

		/// <summary>
		///     Gets or sets my watchlist.
		/// </summary>
		/// <value>My watchlist.</value>
		[BsonIgnore]
		public List<string> MyWatchlist { get; set; }



	}
}