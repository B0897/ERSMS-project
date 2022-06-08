import { Animal } from './animal.model'
import { Account } from './account.model'

export class Owner {
  animals: Animal[] = [];
  accounts: Account[] = [];
  isInterested: string = '';
}
