
import { Component, OnInit } from '@angular/core';
import { BaseEditComponent } from 'base/components/base-edit-component';
import { ActivatedRoute } from '@angular/router';
import { Shell } from 'base/components/shell';
import { GatewayService } from 'features/gateway/services/gateway.service';
import { FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import { Gateway } from 'features/gateway/models/gateway';
import * as moment from 'moment';
import { Result } from 'shared/models/result';
@Component({
    selector: 'app-add-gateway',
    templateUrl: './add-gateway.component.html',
    styleUrls: ['./add-gateway.component.scss'],
})
export class AddGatewayComponent extends BaseEditComponent implements OnInit {
    // for edit or add
    type = '';
    model: Gateway;
    id: string | null = '';
    moment = moment;
    get Service(): GatewayService { return Shell.Injector.get(GatewayService); }
    get Fb(): FormBuilder { return Shell.Injector.get(FormBuilder); }
    constructor(public route: ActivatedRoute) {
        super(route);
        this.getRouteParams();
    }


    ngOnInit() {
        this.initGatewayForm();
    }
    /**
    * Initialize Gateway Form
    */
    initGatewayForm(): void {
        this.form = this.Fb.group({
            id: [null],
            serialNumber: ['', Validators.required],
            name: ['', Validators.required],
            ip: ['', Validators.required],
            devices: this.Fb.array([])
        });

    }

    // debugger;
    //     if (this.isNew) {
    //         this.initDeviceForm();
    //     } else {
    //         this.model.devices.map(() => this.initDeviceForm());
    //         this.form.patchValue(this.model);
    //     }


    /**
     * Initialize Device Form
     */
    initDeviceForm(): void {
        this.gatewayDevices.push(this.Fb.group({
            id: [null],
            vendor: ['', Validators.required],
            createdDate: [this.id ? '' : new Date()],
            status: [1, Validators.required]
        }));
    }

    getRouteParams() {
        this.route.params.subscribe((p: any) => {
            if (p.id != null && p.id !== undefined) {
                this.id = p.id;
                this.isNew = false;
                this.Get(this.id);
            }
        });
    }

    Get(id: any): void {
        this.GetModelFromServer(id, 'GetByIdForEdit').subscribe(
            (data: any) => {
                this.model = data.data;
                this.pathForm();
            },
            (error) => {
                this.Alert.showError(this.Localize.translate.instant('Data.GetError'));
                console.log(error);
            }
        );
    }



    pathForm(): void {
        this.initGatewayForm();
        console.log(this.model);
        this.model.devices.map(() => this.initDeviceForm());
        this.form.patchValue(this.model);

    }

    /**
     * get devices forms controls
     */
    get gatewayDevices() {
        return this.form.get('devices') as FormArray;
    }



    /**
     * prevent only numbers
     *
     * @param {KeyboardEvent} event
     * @returns
     * @memberof AddGatewayComponent
     */
    allowNumbersOnly(event: KeyboardEvent): boolean {
        const regex = /^\d*$/;
        const allowKeys = [8, 9, 37, 38, 39, 40, 46, 110, 190]
        const charKey = event.key;

        if (regex.test(charKey) || event.ctrlKey || event.shiftKey || allowKeys.includes(event.which)) {
            return true;
        }

        return false;
    }


    Submit() {
        super.submitReactive();
    }




}
