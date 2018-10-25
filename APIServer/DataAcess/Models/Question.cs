using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks.Sources;

namespace DataAcess.Models
{
    public class Question
    {
        string id;
        DateTime time;
        List<Tag> tags;
        string title;
        string content;
        List<Answer> answers;
        int watchs;
        int stars;
        string author;
        Answer adoptedAnswer;

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
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public List<Tag> Tags
        {
            get
            {
                return tags;
            }
            set
            {
                tags = value;
            }
        }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>The answers.</value>
        public List<Answer> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
            }
        }
        /// <summary>
        /// Gets or sets the watchs.
        /// </summary>
        /// <value>The watchs.</value>
        public int Watchs
        {
            get
            {
                return watchs;
            }
            set
            {
                watchs = value;
            }
        }
        /// <summary>
        /// Gets or sets the stars.
        /// </summary>
        /// <value>The stars.</value>
        public int Stars
        {
            get
            {
                return stars;
            }
            set
            {
                stars = value;
            }
        }
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        /// <summary>
        /// Gets or sets the adopted answer.
        /// </summary>
        /// <value>The adopted answer.</value>
        public Answer AdoptedAnswer
        {
            get
            {
                return adoptedAnswer;
            }
            set
            {
                adoptedAnswer = value;
            }
        }
    }

    public class Answer
    {
        string id;
        DateTime time;
        string content;
        int approvals;
        int disapprovals;
        List<Reply> replies;
        string author;

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
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        /// <summary>
        /// Gets or sets the approvals.
        /// </summary>
        /// <value>The approvals.</value>
        public int Approvals
        {
            get
            {
                return approvals;
            }
            set
            {
                approvals = value;
            }
        }
        /// <summary>
        /// Gets or sets the disapprovals.
        /// </summary>
        /// <value>The disapprovals.</value>
        public int Disapprovals
        {
            get
            {
                return disapprovals;
            }
            set
            {
                disapprovals = value;
            }
        }
        /// <summary>
        /// Gets or sets the replies.
        /// </summary>
        /// <value>The replies.</value>
        public List<Reply> Replies
        {
            get
            {
                return replies;
            }
            set
            {
                replies = value;
            }
        }
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
    }

    public class Tag
    {
        private string id;
        private string name;
        private string description;

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
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
    }

    public class Reply
    {
        string id;
        DateTime time;
        string content;
        int likes;
        List<Reply> replies;
        string Author;

    }
}