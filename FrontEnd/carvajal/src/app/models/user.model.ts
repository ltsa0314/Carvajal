export class User {
  id: number;
  name: string;
  lastName: string;
  typeIdentificationId: number;
  identification: string;
  email: string;
  password: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.lastName = '';
    this.typeIdentificationId = 0;
    this.identification = '';
    this.email = '';
    this.password = '';
  }
}
