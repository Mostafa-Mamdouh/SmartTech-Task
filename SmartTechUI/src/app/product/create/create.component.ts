import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Location, JsonPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ProductService } from '../product.service';
import { ProductForCreation } from '../product.model';
import { RouterModule, Routes, Router } from '@angular/router';
import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  public productForm: FormGroup;
  constructor(private location: Location,private http: HttpClient,private service:ProductService,private router:Router,public toastr: ToastrManager) { }
  fileData: File = null;
  ProductPhoto: string = '';
  
  ngOnInit() {
    this.productForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(20)]),
      photo: new FormControl(''),
      price: new FormControl('', [Validators.required])
    });
  }
  public hasError = (controlName: string, errorName: string) =>{
    return this.productForm.controls[controlName].hasError(errorName);
  }
  showSuccess() {
    this.toastr.successToastr('Product Saved Successfully.');
  }
  public onCancel = () => {
    this.location.back();
  }



 public onAction(event: any){
  this.fileData = <File>event.target.files[0];
  this.ProductPhoto=this.fileData.name;
 }
 public createProduct = (productFormValue) => {
  if (this.productForm.valid) {
    this.executeProductCreation(productFormValue);
  }
}

private executeProductCreation = (productFormValue) => {
  let productObj: ProductForCreation = {
    Name: productFormValue.name,
    Price: productFormValue.price,
    Photo: this.ProductPhoto 
  }

  let apiUrl = 'api/Products/Add';
  console.log(productObj)

  this.service.create(apiUrl, productObj)
    .subscribe(res => {
      if(this.fileData!=null)
      {
        const formData = new FormData();
        formData.append('file', this.fileData);
        this.http.post('http://localhost:5000/api/Products/Upload', formData)
          .subscribe(res => {
            this.router.navigate(['/', 'products']); 
          })
      }
  
      this.router.navigate(['/', 'products']);     
      this.showSuccess();
    },
    (error => {
     
      this.location.back();
    })
  )
}



}
