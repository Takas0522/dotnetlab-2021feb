export interface OrderInterface {
  orderNo: number;
  orderName: string;
  salesUserId: number;
  salesUserName: string;
  salesDate: Date;
  updateDate: Date;
}

export interface OrderOdattaInterface {
  '@odata.context': string;
  '@odata.nextLink': string;
  value: OrderInterface[];
}
