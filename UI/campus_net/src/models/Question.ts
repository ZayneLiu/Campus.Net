import Tag from '@/models/Tag';

export default class Question {
  // Rank START
  public votes!: number;
  public answers!: number;
  public views!: number;
  // Rank END
  public title!: string;
  public tags!: Tag[];

  /**
   * Creates question
   * @param votes 得票数
   * @param answers 回答数
   * @param views 浏览数
   * @param title 提问标题
   * @param tags 提问标签
   * @returns question
   */
  public CreateQuestion(
    votes: number,
    answers: number,
    views: number,
    title: string,
    tags: Tag[],
  ): Question {
    this.votes = votes;
    this.answers = answers;
    this.views = views;
    this.title = title;
    this.tags = tags;
    return this;
  }
}
