import { Routes } from '@angular/router';
import { LayoutComponent } from './components/layout/layout.component';
import { HomeComponent } from './components/layout/home/home.component';
import { AboutComponent } from './components/layout/about/about.component';
import { ContactComponent } from './components/layout/contact/contact.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PostDetailComponent } from './components/layout/post-detail/post-detail.component';
import { AdminComponent } from './components/admin/admin/admin.component';
import { AuthService } from './services/auth.service';
import { inject } from '@angular/core';
import { PostsComponent } from './components/admin/posts/posts.component';
import { SocialsComponent } from './components/admin/socials/socials.component';
import { MessagesComponent } from './components/admin/messages/messages.component';
import { AdminAboutComponent } from './components/admin/about/about.component';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        component: HomeComponent,
      },
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'about',
        component: AboutComponent
      },
      {
        path: 'contact',
        component: ContactComponent
      },
      {
        path: 'post/:postUrl',
        component: PostDetailComponent
      }
    ]
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [() => inject(AuthService).isAuthenticated()],
    children: [
      {
        path: 'posts',
        component: PostsComponent
      },
      {
        path: 'socials',
        component: SocialsComponent
      },
      {
        path: 'messages',
        component: MessagesComponent
      },
      {
        path: 'about',
        component: AdminAboutComponent
      }
    ]
  },
  {
    path: '**',
    component: NotFoundComponent,
  }
];
