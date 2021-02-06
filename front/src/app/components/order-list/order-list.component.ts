import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { OrderInterface } from 'src/app/models/order.model';
import { OrderService } from './order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {

  displayColumns: string[] = ['orderNo', 'orderName', 'salesUserId', 'salesUserName', 'salesDate', 'updateDate'];
  dataSource!: MatTableDataSource<OrderInterface>;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(
    private service: OrderService
  ) { }

  ngOnInit(): void {
    this.tableSetting();
    this.service.fetchData();
  }

  private tableSetting(): void {
    this.dataSource = new MatTableDataSource<OrderInterface>([]);
    this.dataSource.paginator = this.paginator;
    this.service.data$.subscribe(x => {
      this.dataSource.data = x;
    });
  }

}
