import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from '../list/list.component';
import { CreateComponent } from '../create/create.component';
import { UpdateComponent } from '../update/update.component';
import { DetailsComponent } from '../details/details.component';




const routes: Routes = [
    {
        path:'',
        component:ListComponent
      },{
        path:'add',
        component:CreateComponent
      },
      {
        path:'edit/:id',
        component:UpdateComponent
      },
      {
        path:'details/:id',
        component:DetailsComponent
      },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }