import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UsersService } from '../../../../services/users.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
})
export class UserListComponent implements OnInit {
  public users: User[] = [];
  constructor(private srvUsers: UsersService, private router: Router) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.srvUsers.getAll().subscribe((response) => (this.users = response));
  }

  onInfo(id: number) {
    this.router.navigate([
      this.router.routerState.snapshot.url + '/info/' + id,
    ]);
  }
  onInsert() {
    this.router.navigate([this.router.routerState.snapshot.url + '/insert/']);
  }
  onUpdate(id: number) {
    this.router.navigate([
      this.router.routerState.snapshot.url + '/update/' + id,
    ]);
  }
  onDelete(id: number) {
    this.srvUsers.delete(id).subscribe(() => this.loadData());
  }
}
