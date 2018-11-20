import Author from './Author';
import Column from './Column';
import Tag from './Tag';

/**
 * 帖子
 */
export default class Post {
  public title!: string;
  public type!: string;
  public author!: Author;
  public content!: string;
  public approvals!: number;
  public favorites!: number;
  public column!: Column;
  public tags!: Tag[];
  constructor() {
    // super();
  }
  /**
   * Creates an instance of post model.
   * @param title 标题
   * @param type 类型
   * @param author 作者
   * @param content 内容
   * @param approvals 得票数
   * @param favorites 收藏数
   * @param column 专栏
   * @param tags 标签列表
   */
  public createPost(
    title: string,
    type: string,
    author: {
      id: string;
      url: string;
      name: string;
      avatar: string;
    },
    content: string,
    approvals: number,
    favorites: number,
    column: {
      id: string;
      name: string;
      url: string;
    },
    tags: Tag[],
  ): Post {
    this.title = title;
    this.content = content;
    this.author = author;
    this.approvals = approvals;
    this.favorites = favorites;
    this.column = column;
    this.tags = tags;
    this.type = type;
    return this;
  }
}
