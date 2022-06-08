import { PreferenceKind } from './preference-kind.model'

export class Account {
  id: number = 0;
  login: string = '';
  password: number = null as any;
  isInstitution: boolean = false;
  name: string = '';
  surname: string = '';
  institutionName: string = '';
  email: string = '';
  telephone: string = '';
  town: string = '';
  address: string = '';
  secret: string = '';
  paypal: string = '';
  coord: string = '';
  code: number = null as any;
}

