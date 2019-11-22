import { NgModule} from '@angular/core';
import { ListComponent } from '../list/list.component';
import { CreateComponent } from '../create/create.component';
import { UpdateComponent } from '../update/update.component';
import { ProductRoutingModule } from './product-routing.module';
import { ProductService } from '../product.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule, removeStyles } from '@angular/flex-layout';
import { MatFileUploadModule } from 'mat-file-upload';
import {HttpClientModule } from '@angular/common/http';
import { Ng2FileInputModule } from 'ng2-file-input';
import { DetailsComponent } from '../details/details.component';
import { ExcelService } from '../excel-services.service';
import { ToastrModule } from 'ng6-toastr-notifications';
@NgModule({
  declarations: [
    ListComponent,
    CreateComponent,
    UpdateComponent,
    DetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ProductRoutingModule,
    MaterialModule,
    FlexLayoutModule,
    MatFileUploadModule,
    HttpClientModule,

    Ng2FileInputModule.forRoot({
      dropText:"Select photo",
      browseText:"Browse",
      removeText:"Remove",
      invalidFileText:"You have picked an invalid or disallowed file.",
      invalidFileTimeout:8000,
      removable:true,
      multiple:false,
      showPreviews:true,
      extensions:['jpg','png']
    }),
    ToastrModule.forRoot()
  ],
  providers: [ProductService,ExcelService],
 
})
export class ProductModule { }
