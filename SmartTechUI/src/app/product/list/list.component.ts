import { Router } from '@angular/router';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { ProductService } from '../product.service';
import { Product } from '../product.model';
import { ExcelService } from '../excel-services.service';
import { ToastrManager } from 'ng6-toastr-notifications';



@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit,AfterViewInit  {


  public displayedColumns = ['Id','Name', 'Price', 'Photo', 'details', 'delete'
];
  public dataSource = new MatTableDataSource<Product>();
  @ViewChild(MatSort,{static: false}) sort: MatSort;
  @ViewChild(MatPaginator,{static: false}) paginator: MatPaginator;
  constructor(private Service: ProductService,private route:Router,private excelService:ExcelService,public toastr: ToastrManager) { }

  ngOnInit() {
  this.getAllProducts ();
 
  }
     
  showInfo() {
    this.toastr.infoToastr('Product Deleted Successfully.');
  }
  exportTable(){
    this.excelService.exportAsExcelFile(this.dataSource.data , 'Products')
  }
  ngAfterViewInit(): void {
    console.log(this.dataSource)
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
  public getAllProducts () {
    this.Service.getData('api/Products')
    .subscribe(res => {
     this.dataSource.data = res as Product[];
    })

  }


  public redirectToDetails = (id: string) => {
    let url: string = `/products/details/${id}`;
    this.route.navigate([url]);
  }
 
  public redirectToUpdate = (id: string) => {
    
  }
  public redirectToDelete = (id: string) => {
    
    this.Service.delete('api/Products/'+id+'')
    .subscribe(res => {
      this.getAllProducts ();
      this.showInfo();
    })
  }

}
