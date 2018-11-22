#region

using System;
using System.Collections.Generic;

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
		public string Id { get; set; }

		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Username { get; set; }

		/// <summary>
		///     Gets or sets the scid.
		/// </summary>
		/// <value>The scid.</value>
		public string SCID { get; set; }

		/// <summary>
		///     Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password { get; set; }

		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		public string Email { get; set; }

		/// <summary>
		///     Gets or sets the tel.
		/// </summary>
		/// <value>The tel.</value>
		public string Tel { get; set; }

		/// <summary>
		///     Gets or sets the real-name.
		/// </summary>
		/// <value>The real-name.</value>
		public string RealName { get; set; }

		/// <summary>
		///     Gets or sets the gender.
		/// </summary>
		/// <value>The gender.</value>
		public string Gender { get; set; }

		/// <summary>
		///     Gets or sets the birthday.
		/// </summary>
		/// <value>The birthday.</value>
		public DateTime Birthday { get; set; }

		/// <summary>
		///     Gets or sets the biography.
		/// </summary>
		/// <value>The biography.</value>
		public string Biography { get; set; }

		/// <summary>
		///     Gets or sets my involvement.
		/// </summary>
		/// <value>My involvement.</value>
		public List<string> MyInvolvement { get; set; }

		/// <summary>
		///     Gets or sets my stars.
		/// </summary>
		/// <value>My stars.</value>
		public List<string> MyStars { get; set; }

		/// <summary>
		///     Gets or sets my watchlist.
		/// </summary>
		/// <value>My watchlist.</value>
		public List<string> MyWatchlist { get; set; }



	}
}