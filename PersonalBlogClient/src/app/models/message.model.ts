import { BaseModel } from "./base.model";

export class MessageModel extends BaseModel {
  name: string = '';
  email: string = '';
  content: string = '';
}
