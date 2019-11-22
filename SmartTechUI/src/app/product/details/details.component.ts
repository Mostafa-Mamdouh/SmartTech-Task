import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { Product } from '../product.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  public product: Product;

  constructor(private service: ProductService, private router: Router, 
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getOwnerDetails();
  }

  private getOwnerDetails = () =>{
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = `api/products/${id}`;
    this.service.getData(apiUrl)
    .subscribe(res => {
      this.product = res as Product;
    },
    (error) =>{
      alert(error)
    })
  }
}
