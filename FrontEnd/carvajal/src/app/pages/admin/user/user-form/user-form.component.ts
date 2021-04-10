import { Component, OnInit, Type } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { TypeIdentification } from '../../../../models/type-identification.model';
import { TypeIdentificationsService } from '../../../../services/type-identifications.service';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from '../../../../services/users.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  title: string = 'Insert';
  isInfo: boolean = false;
  id: number = 0;
  model: User = new User();
  typeIdentifications: TypeIdentification[] = [];
  constructor(
    private srvUsers: UsersService,
    private srvTypeidentifications: TypeIdentificationsService,
    private location: Location,
    private route: ActivatedRoute,
    public router: Router
  ) {
    this.title = this.route.snapshot.url[0].path;
    this.isInfo = this.route.snapshot.url[0].path === 'info' ? true : false;

    const { id } = this.route.snapshot.params;

    this.srvUsers.getById(id).subscribe((response) => {
      if (!response) this.location.back();
      this.model = response;
    });

    this.srvTypeidentifications
      .getAll()
      .subscribe((response) => (this.typeIdentifications = response));
  }

  ngOnInit(): void {}

  onCancel(): void {
    this.location.back();
  }
  onSave(): void {
    if (this.title === 'insert') {
      this.srvUsers.insert(this.model).subscribe((result) => {
        this.location.back();
      },(error)=> alert(error.error));
    }
    if (this.title === 'update') {
      this.srvUsers.update(this.model).subscribe((result) => {
        this.location.back();
      },(error)=> alert(error.error));
    }
  }
}
