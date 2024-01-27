import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { OperationEntryComponent } from './operation-entry/operation-entry.component';
import { OperationsListComponent } from './operations-list/operations-list.component';
import { Routes,RouterModule } from '@angular/router';
import { FilterPipe } from './filter.pipe';
import { HeaderComponent } from './header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FilterStringPipe } from './filter-string.pipe';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { InterceptorService } from './auth/interceptor.service';
import { AuthGuardService } from './auth/auth-guard.service';

const appRouts :Routes=[
  {path: '', component: AuthComponent},
  {path: 'auth', component: AuthComponent},
  {path: 'operation-entry',canActivate:[AuthGuardService], component: OperationEntryComponent},
  {path: 'operations-list',canActivate:[AuthGuardService], component: OperationsListComponent},
  {path: 'product-management', canActivate:[AuthGuardService],data: { roles: ['admin'] },
    loadChildren: () => import('./product-management/product-management.module').then((m) => m.ProductManagementModule)},
  {path: '**',  redirectTo: '/auth'}
]
@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    OperationEntryComponent,
    OperationsListComponent,
    FilterPipe,
    HeaderComponent,
    FilterStringPipe
    
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot(appRouts),
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true,
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
