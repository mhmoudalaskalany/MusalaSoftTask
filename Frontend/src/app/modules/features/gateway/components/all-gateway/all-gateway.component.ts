import { Component, OnInit } from '@angular/core';
import { Shell } from 'base/components/shell';
import { BaseListComponent } from 'base/components/base-list-component';
import { TableOptions } from 'shared/components/data-table/models/tableOptions';
import { GatewayService } from 'features/gateway/services/gateway.service';

@Component({
  selector: 'app-all-gateway',
  templateUrl: './all-gateway.component.html',
  styleUrls: ['./all-gateway.component.scss'],
})
export class AllGatewayComponent extends BaseListComponent implements OnInit {
  // private fields
  tableOptions: TableOptions = {
    inputUrl: {
      getAll: 'GET-GATEWAY',
      delete: 'DELETE-GATEWAY',
    },
  };
  // Services
  get Service(): GatewayService { return Shell.Injector.get(GatewayService); }
  constructor() {
    super();
  }

  ngOnInit(): void {
    this.initializeTableColumns();
    this.initializeTableActions();
  }

  initializeTableColumns(): void {
    this.tableOptions.inputCols = [
      {
        field: 'name',
        header: 'Name',
        sort: true,
        sortCol: 'name',
        filterMode: 'text',
      },
      {
        field: 'serialNumber',
        header: 'SerialNumber',
        sort: true,
        sortCol: 'serialNumber',
        filterMode: 'text',
      },
      {
        field: 'ip',
        header: 'IP',
        sort: true,
        sortCol: 'ip',
        filterMode: 'text',
      },
    ];
  }
  initializeTableActions(): void {
    this.tableOptions.inputActions = [
      {
        isEdit: true,
        name: 'Edit',
        icon: 'bx bxs-edit',
        color: 'text-gradient-success'
      },
      {
        isDelete: true,
        name: 'Delete',
        icon: 'bx bx-trash',
        color: 'text-gradient-danger'
      },
      {
        isView: true,
        name: 'View',
        icon: 'bx bxs-info-circle',
        color: 'text-gradient-warning'
      }
    ];
  }


}
