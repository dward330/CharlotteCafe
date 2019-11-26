import { OrderEpics } from './_state/epics/order.epics';
import { Adal6Service, Adal6HTTPService } from 'adal-angular6';
import { ResponsiveService } from './_common/services/Responsive.service';
import { StationService } from './_state/services/station.service';
import { ResponsiveModule } from 'ngx-responsive'
import { isDevMode } from '@angular/core';
import { HttpClient, HttpClientModule  } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { UserService } from './_state/services/user.service';
import { OrderActions } from './_state/actions/order.actions';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppHeaderComponent } from './_common/app-header/app-header.component';
import { MainListComponent } from './menu-list/main-list/main-list.component';
import { MainListItemComponent } from './menu-list/main-list-item/main-list-item.component';
import { PinnedListItemComponent } from './menu-list/pinned-list-item/pinned-list-item.component';
import { StationCardComponent } from './station/station-card/station-card.component';
import { CartIconComponent } from './shopping/cart-icon/cart-icon.component';
import { OrderListComponent } from './shopping/order-list/order-list.component';
import { OrderListItemComponent } from './shopping/order-list-item/order-list-item.component';
import { OrderListItemOptionsComponent } from './shopping/order-list-item-options/order-list-item-options.component';
import { CheckoutComponent } from './shopping/checkout/checkout.component';
import { OnlineOrderingPageComponent } from './_pages/online-ordering-page/online-ordering-page.component';
import { NgReduxModule, NgRedux, DevToolsExtension } from '@angular-redux/store';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { rootReducer, INITIAL_STATE } from './_state/order.store';
import { IAppState } from './_state/IAppState';
import { LoginPageComponent } from './_pages/authentication/login-page/login-page.component';
import { RegisterPageComponent } from './_pages/authentication/register-page/register-page.component';
import { AuthGuard } from './_authentication/auth.guard';
import { SessionActions } from './_state/actions/session.actions';
import { ModalComponent } from './_common/modal/modal.component';
import { OrderListItemOptionsModalComponent } from './shopping/order-list-item-options-modal/order-list-item-options-modal.component';
import { OrderHistoryComponent } from './_pages/order-history/order-history.component';
import { createEpicMiddleware } from 'redux-observable';

@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    MainListComponent,
    MainListItemComponent,
    PinnedListItemComponent,
    StationCardComponent,
    CartIconComponent,
    OrderListComponent,
    OrderListItemComponent,
    OrderListItemOptionsComponent,
    CheckoutComponent,
    OnlineOrderingPageComponent,
    LoginPageComponent,
    RegisterPageComponent,
    ModalComponent,
    OrderListItemOptionsModalComponent,
    OrderHistoryComponent
  ],
  imports: [
    BrowserModule,
    NgReduxModule,
    FormsModule,
    HttpClientModule,
    HttpModule,
    ReactiveFormsModule,
    AngularFontAwesomeModule,
    ResponsiveModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'order', pathMatch: 'full' },
      {
        path: 'orderhistory',
        component: OrderHistoryComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'order',
        component: OnlineOrderingPageComponent,
        canActivate: [AuthGuard],
        children: [
          { path: 'checkout', component: CheckoutComponent, outlet: 'modal' },
        ]
      },
      { path: 'login', component: LoginPageComponent },
      { path: '**', redirectTo: 'home' },
    ])
  ],
  providers: [
    OrderActions,
    SessionActions,
    OrderEpics,
    AuthGuard,
    UserService,
    StationService,
    ResponsiveService,
    Adal6Service,
    { provide: Adal6HTTPService, useFactory: Adal6HTTPService.factory, deps: [HttpClient, Adal6Service] }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(ngRedux: NgRedux<IAppState>,
    private devTools: DevToolsExtension,
    private epics:OrderEpics) {

    let enhancers = [];
    let middleware =  createEpicMiddleware()
    if (isDevMode()) {
      enhancers = [...enhancers, devTools.enhancer()];
    }

    ngRedux.configureStore(
      rootReducer,
      INITIAL_STATE,
      [middleware],
      enhancers);
      middleware.run(this.epics.getStation)
      middleware.run(this.epics.saveCurrentOrder)
  }
}
