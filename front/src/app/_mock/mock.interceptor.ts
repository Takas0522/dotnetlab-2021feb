import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay, dematerialize, materialize, mergeMap } from 'rxjs/operators';
import { MockOrderService } from './mock-order.service';

const ok = (body?: any): Observable<HttpResponse<any>> => {
    return of(new HttpResponse({ status: 200, body }));
};

@Injectable()
export class MockInterceptor implements HttpInterceptor {

  private mockOrder: MockOrderService;
  constructor() {
    this.mockOrder = new MockOrderService();
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const { url, method, headers, body } = req;
    const getOrderDatas = (): Observable<HttpResponse<any>> => {
      const datas = this.mockOrder.fetchMockData(url);
      return ok(datas);
    };

    const handleRoute = (): any => {
      switch (true) {
        case url.includes('/order') && method === 'GET':
          return getOrderDatas();
        default:
          next.handle(req);
      }
    };



    return of(null)
      .pipe(
        mergeMap(handleRoute)
      )
      .pipe(materialize())
      .pipe(delay(100))
      .pipe(dematerialize<any>());
  }

}
