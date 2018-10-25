using System;
using System.Collections.Generic;

namespace DataAcess.Models
{
    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        private string id;
        private string name;
        private string scid;
        private string password;
        private string email;
        private string tel;
        private string realname;
        private string gender;
        private DateTime birthday;
        private string biography;
        private List<string> myInvolvements;
        private List<string> myStars;
        private List<string> myWatchlist;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the scid.
        /// </summary>
        /// <value>The scid.</value>
        public string SCID
        {
            get
            {
                return scid;
            }
            set
            {
                scid = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        /// <summary>
        /// Gets or sets the tel.
        /// </summary>
        /// <value>The tel.</value>
        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                tel = value;
            }
        }

        /// <summary>
        /// Gets or sets the realname.
        /// </summary>
        /// <value>The realname.</value>
        public string Realname
        {
            get
            {
                return realname;
            }
            set
            {
                realname = value;
            }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        /// <summary>
        /// Gets or sets the biography.
        /// </summary>
        /// <value>The biography.</value>
        public string Biography
        {
            get
            {
                return biography;
            }
            set
            {
                biography = value;
            }
        }

        /// <summary>
        /// Gets or sets my involvement.
        /// </summary>
        /// <value>My involvement.</value>
        public List<string> MyInvolvement
        {
            get
            {
                return myInvolvements;
            }
            set
            {
                myInvolvements = value;
            }
        }

        /// <summary>
        /// Gets or sets my stars.
        /// </summary>
        /// <value>My stars.</value>
        public List<string> MyStars
        {
            get
            {
                return myStars;
            }
            set
            {
                myStars = value;
            }
        }

        /// <summary>
        /// Gets or sets my watchlist.
        /// </summary>
        /// <value>My watchlist.</value>
        public List<string> MyWatchlist
        {
            get
            {
                return myWatchlist;
            }
            set
            {
                myWatchlist = value;
            }
        }
    }
}
