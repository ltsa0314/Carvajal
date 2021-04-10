import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserFormComponent } from './user-form/user-form.component';
import { UserListComponent } from './user-list/user-list.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    component: UserListComponent,
  },
  {
    path: 'insert',
    component: UserFormComponent,
  },
  {
    path: 'update/:id',
    component: UserFormComponent,
  },
  {
    path: 'info/:id',
    component: UserFormComponent,
  },
];

@NgModule({
  declarations: [UserFormComponent, UserListComponent],
  imports: [CommonModule,FormsModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserModule {}
