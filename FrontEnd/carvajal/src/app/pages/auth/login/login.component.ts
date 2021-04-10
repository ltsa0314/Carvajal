import { AuthService } from './../../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/models/login.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  model: Login = new Login();
  constructor(private srvAuth: AuthService, private router: Router) {}

  ngOnInit(): void {}

  onLogin() {
    this.srvAuth.login(this.model).subscribe(
      (response) => this.router.navigateByUrl('/admin/users'),
      (error) => alert(error.error)
    );
  }
}
