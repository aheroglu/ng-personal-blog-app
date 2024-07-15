import { BaseModel } from "./base.model";

export class PostModel extends BaseModel {
  title: string = '';
  postUrl: string = '';
  image: any;
  description: string = '';
  content: string = '';
}
