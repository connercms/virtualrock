export interface SlackResponse {
  ok: boolean;
  app_id: string;
  authed_user: {
    id: string;
    scope: string;
    access_token: string;
    token_type: string;
  };
  team: {
    id: string;
  };
  enterprise: any;
  is_enterprise_install: boolean;
}
