import { Injectable } from '@angular/core';
import { OrderInterface } from '../models/order.model';

export class MockOrderService {

  constructor() {
    this.genMockData();
  }

  private data: OrderInterface[] = [];

  private genMockData(): void {
    const datas = [...Array(10000).keys()].map(m => {
      const now = new Date();
      const data: OrderInterface = {
        orderNo: m,
        orderName: `${m}件目の受注`,
        salesDate: new Date(now.setDate(now.getDate() + m)),
        salesUserId: m,
        salesUserName: `${m}さん`,
        updateDate: new Date()
      };
      return data;
    });
    this.data = datas;
  }

  fetchMockData(url: string): OrderInterface[] {
    switch (true) {
      case url.includes('top'):
        return this.data.slice(0, 100);
      case url.includes('skip'):
        return this.data.slice(100);
      case url.includes('filter'):
        return [];
      default:
        return this.data;
    }
  }
}
