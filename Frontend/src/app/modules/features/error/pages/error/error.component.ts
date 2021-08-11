import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit {

  errorNumber: string | null = '';

  constructor(private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.errorNumber = this.activeRoute.snapshot.paramMap.get('errorNumber');
  }
}
