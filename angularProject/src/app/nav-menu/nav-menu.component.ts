import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  navigationItems = [
    { id: '10', name: 'Profil', link: '/profile', isVisible: false, class: '' },
    { id: '20', name: 'Moje', link: '/listing?category=owner', isVisible: true, class: '' },
    { id: '30', name: 'Lubię', link: '/listing?category=follow', isVisible: true, class: '' },
    { id: '01', name: 'Szukaj', link: '/listing', isVisible: true, class: '' },
  ];

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
