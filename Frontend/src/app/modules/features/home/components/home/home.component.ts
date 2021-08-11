import { Component, OnInit } from '@angular/core';
import { Shell } from 'base/components/shell';
import { TranslationService } from 'core/services/localization/translation.service';
import { HomeService } from 'features/home/services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  profileModel: any = {};
  cards: any = {};

  get HomeService(): HomeService { return Shell.Injector.get(HomeService); }
  get Localize(): TranslationService { return Shell.Injector.get(TranslationService); }



  constructor() { }

  ngOnInit(): void {
    this.getDashboardCounts();

  }

  getDashboardCounts(): void {
    this.HomeService.getDashboardCounts().subscribe((res: any) => {
      console.log(res);

      this.cards = res.data;
    });
  }



}
