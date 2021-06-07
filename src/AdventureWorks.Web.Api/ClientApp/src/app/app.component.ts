import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ReactiveObject } from 'app/models/misc/reactive-object';
import { ComponentCacheService } from 'app/services/common/component-cache.service';
import { DynamicThemeService } from 'app/services/common/dynamic-theme.service';
import { AddressesService } from 'app/services/data/person/addresses.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent {
  private _destroy = new Subject<boolean>();

  addressLine1: string;

  currentTheme = new ReactiveObject<string>(null, this.componentCacheService, 'app/currentTheme');

  constructor(private readonly dynamicThemeService: DynamicThemeService, private readonly componentCacheService: ComponentCacheService, private readonly addressesService: AddressesService) { }

  ngOnInit(): void {
    this.dynamicThemeService.onThemeChanged.pipe(takeUntil(this._destroy)).subscribe((themeType) => {
      this.currentTheme.value = themeType;
    });

    this.addressesService.get(55).toPromise().then(res => {
      this.addressLine1 = res.addressLine1;
    }, err => {

    });

    this.addressesService.get(55).pipe(
      takeUntil(this._destroy)
    ).subscribe(res => {
      this.addressLine1 = res.addressLine1;
    });

  }

  ngOnDestroy(): void {
    this._destroy.next(true);
    this._destroy.complete();
  }
}
