import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-add-edit',
  templateUrl: './product-add-edit.component.html',
  styleUrls: ['./product-add-edit.component.css']
})
export class ProductAddEditComponent implements OnInit {
  productForm !: FormGroup;
  submitted = false;
  id !: any;
  isAddMode !: boolean;

  constructor(private fb: FormBuilder, 
              private productService : ProductService,
              private router : Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.InitializeformControls();
  }

  InitializeformControls() {
    if(this.route.snapshot.params['id'] != null){
      this.id = parseInt(atob(this.route.snapshot.params['id']));
    }
    this.isAddMode = !this.id;

    this.productForm = this.fb.group({
      ProductName: ['', Validators.required],
      Stock: ['', [Validators.required,Validators.pattern("^[0-9]*$")]],
      Price: ['', [Validators.required,Validators.pattern("^[0-9]*$")]]
    })

    if(!this.isAddMode) {
      this.productService.getProductById(this.id).subscribe((pro) => {
        this.productForm.patchValue(pro);
      })
    }
  }

  get _form(){
    return this.productForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    if(this.productForm.invalid) {
      return;
    } 

    if (this.isAddMode) {
      this.addProduct();
  } else {
      this.updateProduct();
  }

  }

  addProduct (){
    this.productService.addProduct(this.productForm.value).subscribe((res) => {
      this.productForm.reset();
      this.router.navigate(['/product']);
    })
  }

  updateProduct() {
    this.productService.updateProduct(this.id, this.productForm.value).subscribe((res) => {
      this.productForm.reset();
      this.router.navigate(['/product']);
    })
  }


}
