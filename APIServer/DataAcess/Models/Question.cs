using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Question
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id;
        /// <summary>
        /// 得票数
        /// </summary>
        public int votes;
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int views;
        /// <summary>
        /// 回答数
        /// </summary>
        public int answers;
        /// <summary>
        /// 问题标题
        /// </summary>
        public string title;
        /// <summary>
        /// 标签
        /// </summary>
        public List<Tag> tags;
        /// <summary>
        /// 提问时间
        /// </summary>
        public DateTime time;
        /// <summary>
        /// 内容
        /// </summary>
        public string content;
        /// <summary>
        /// 作者
        /// </summary>
        public string author;

        //public Answer adoptedAnswer;
        //public List<Answer> answers;
        //public int watchs;
        //public int stars;

        ///// <summary>
        ///// Gets or sets the identifier.
        ///// </summary>
        ///// <value>The identifier.</value>
        //public string ID
        //{
        //    get
        //    {
        //        return id;
        //    }
        //    set
        //    {
        //        id = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the time.
        ///// </summary>
        ///// <value>The time.</value>
        //public DateTime Time
        //{
        //    get
        //    {
        //        return time;
        //    }
        //    set
        //    {
        //        time = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the tags.
        ///// </summary>
        ///// <value>The tags.</value>
        //public List<Tag> Tags
        //{
        //    get
        //    {
        //        return tags;
        //    }
        //    set
        //    {
        //        tags = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the title.
        ///// </summary>
        ///// <value>The title.</value>
        //public string Title
        //{
        //    get
        //    {
        //        return title;
        //    }
        //    set
        //    {
        //        title = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the content.
        ///// </summary>
        ///// <value>The content.</value>
        //public string Content
        //{
        //    get
        //    {
        //        return content;
        //    }
        //    set
        //    {
        //        content = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the answers.
        ///// </summary>
        ///// <value>The answers.</value>
        //public List<Answer> Answers
        //{
        //    get
        //    {
        //        return answers;
        //    }
        //    set
        //    {
        //        answers = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the watchs.
        ///// </summary>
        ///// <value>The watchs.</value>
        //public int Watchs
        //{
        //    get
        //    {
        //        return watchs;
        //    }
        //    set
        //    {
        //        watchs = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the stars.
        ///// </summary>
        ///// <value>The stars.</value>
        //public int Stars
        //{
        //    get
        //    {
        //        return stars;
        //    }
        //    set
        //    {
        //        stars = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the author.
        ///// </summary>
        ///// <value>The author.</value>
        //public string Author
        //{
        //    get
        //    {
        //        return author;
        //    }
        //    set
        //    {
        //        author = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the adopted answer.
        ///// </summary>
        ///// <value>The adopted answer.</value>
        //public Answer AdoptedAnswer
        //{
        //    get
        //    {
        //        return adoptedAnswer;
        //    }
        //    set
        //    {
        //        adoptedAnswer = value;
        //    }
        //}
    }

    public class Answer
    {
        public string id;
        public DateTime time;
        public string content;
        public int approvals;
        public int disapprovals;
        public List<Reply> replies;
        public string author;

        ///// <summary>
        ///// Gets or sets the identifier.
        ///// </summary>
        ///// <value>The identifier.</value>
        //public string ID
        //{
        //    get
        //    {
        //        return id;
        //    }
        //    set
        //    {
        //        id = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the time.
        ///// </summary>
        ///// <value>The time.</value>
        //public DateTime Time
        //{
        //    get
        //    {
        //        return time;
        //    }
        //    set
        //    {
        //        time = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the content.
        ///// </summary>
        ///// <value>The content.</value>
        //public string Content
        //{
        //    get
        //    {
        //        return content;
        //    }
        //    set
        //    {
        //        content = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the approvals.
        ///// </summary>
        ///// <value>The approvals.</value>
        //public int Approvals
        //{
        //    get
        //    {
        //        return approvals;
        //    }
        //    set
        //    {
        //        approvals = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the disapprovals.
        ///// </summary>
        ///// <value>The disapprovals.</value>
        //public int Disapprovals
        //{
        //    get
        //    {
        //        return disapprovals;
        //    }
        //    set
        //    {
        //        disapprovals = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the replies.
        ///// </summary>
        ///// <value>The replies.</value>
        //public List<Reply> Replies
        //{
        //    get
        //    {
        //        return replies;
        //    }
        //    set
        //    {
        //        replies = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the author.
        ///// </summary>
        ///// <value>The author.</value>
        //public string Author
        //{
        //    get
        //    {
        //        return author;
        //    }
        //    set
        //    {
        //        author = value;
        //    }
        //}
    }

    public class Tag
    {
        public string id;
        public string name;
        public string description;

        ///// <summary>
        ///// Gets or sets the identifier.
        ///// </summary>
        ///// <value>The identifier.</value>
        //public string ID
        //{
        //    get
        //    {
        //        return id;
        //    }
        //    set
        //    {
        //        id = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the name.
        ///// </summary>
        ///// <value>The name.</value>
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}
        ///// <summary>
        ///// Gets or sets the description.
        ///// </summary>
        ///// <value>The description.</value>
        //public string Description
        //{
        //    get
        //    {
        //        return description;
        //    }
        //    set
        //    {
        //        description = value;
        //    }
        //}
    }

    public class Reply
    {
        public string id;
        public DateTime time;
        public string content;
        public int likes;
        public List<Reply> replies;
        public string author;

        //public string ID
        //{
        //    get
        //    {
        //        return id;
        //    }
        //    set
        //    {
        //        id = value;
        //    }
        //}

        //public DateTime Time
        //{
        //    get
        //    {
        //        return time;
        //    }
        //    set
        //    {
        //        time = value;
        //    }
        //}

        //public string Content
        //{
        //    get
        //    {
        //        return content;
        //    }
        //    set
        //    {
        //        content = value;
        //    }
        //}

        //public int Likes
        //{
        //    get
        //    {
        //        return likes;
        //    }
        //    set
        //    {
        //        likes = value;
        //    }
        //}

        //public List<Reply> Replies
        //{
        //    get
        //    {
        //        return replies;
        //    }
        //    set
        //    {
        //        replies = value;
        //    }
        //}

        //public string Author
        //{
        //    get
        //    {
        //        return author;
        //    }
        //    set
        //    {
        //        author = value;
        //    }
        //}
    }
}