import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.username, this.password).subscribe(
      () => {
        this.router.navigate(['/kasa']);  // Prilagodite putanju nakon uspješne prijave
      },
      (error: any) => {
        this.errorMessage = 'Neispravno korisničko ime ili lozinka';
        console.error('Login error', error);
      }
    );
  }
}

