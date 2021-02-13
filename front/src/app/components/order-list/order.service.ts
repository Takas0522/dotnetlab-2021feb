import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, interval, Observable, Subscription } from 'rxjs';
import { OrderInterface, OrderOdattaInterface } from 'src/app/models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private data: BehaviorSubject<OrderInterface[]> = new BehaviorSubject<OrderInterface[]>([]);
  get data$(): Observable<OrderInterface[]> {
    return this.data.asObservable();
  }
  private fetchDate!: Date;
  private intervalGetData!: Subscription;

  constructor(
    private httpClient: HttpClient
  ) { }

  fetchAllData(): void {
    this.httpClient.get<OrderInterface[]>('/api/orders/full').subscribe(x => {
      this.data.next(x);
    });
  }

  fetchData(): void {
    if (this.data.value.length !== 0) {
      this.data.next(this.data.value);
      return;
    }
    this.httpClient.get<OrderOdattaInterface>('/api/orders?$top=100').subscribe(x => {
      this.data.next(x.value);
      this.fetchRemainingData('?$skip=100');
    });
  }

  private fetchRemainingData(param: string): void {
    this.fetchDate = new Date();
    this.httpClient.get<OrderOdattaInterface>(`/api/orders${param}`).subscribe(x => {
      this.updateData(x.value);
      if (x['@odata.nextLink'] != null && x['@odata.nextLink'] !== '') {
        const url = new URL(x['@odata.nextLink']);
        const nextlinkParam = url.search;
        this.fetchRemainingData(nextlinkParam);
      } else {
        this.fetchUpdateData();
      }
    });
  }

  private fetchUpdateData(): void {
    const now = new Date();
    this.intervalGetData = interval(1 * 60 * 1000).subscribe(_ => {
      const dateSt = this.fetchDate.toISOString();
      this.httpClient.get<OrderOdattaInterface>(`/api/orders?$filter=updateDate+ge+${dateSt}`).subscribe(x => {
        this.updateData(x.value);
        this.fetchDate = now;
      });
    });
  }

  private updateData(datas: OrderInterface[]): void {
    let origin = [...this.data.value];
    const insertDatas: OrderInterface[] = [];
    datas.forEach(data => {
      const index = origin.findIndex(f => f.orderNo === data.orderNo);
      if (index !== -1) {
        origin[index] = data;
      } else {
        insertDatas.push(data);
      }
    });
    if (insertDatas.length > 0) {
      origin = origin.concat(...insertDatas);
    }
    this.data.next(origin);
  }

  destroy(): void {
    this.intervalGetData.unsubscribe();
  }
}
