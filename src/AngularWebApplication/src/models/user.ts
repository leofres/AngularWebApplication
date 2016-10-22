export class User{
  private login: string;
  private id: number;
  private avatar_url: string;
  private gravatar_id: string;
  private url: string;
  private html_url: string;
  private followers_url: string;
  private following_url: string;
  private gists_url: string;
  private starred_url: string;
  private subscriptions_url: string;
  private organizations_url: string;
  private repos_url: string;
  private events_url: string;
  private received_events_url: string;
  private type: string;
  private site_admin: boolean;

  public  nombre(){
    return this.login;
  }
}
