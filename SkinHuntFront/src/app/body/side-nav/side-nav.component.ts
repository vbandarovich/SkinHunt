import {Component, signal} from '@angular/core';
import {SidebarTabs} from "../../models/sidebar-tabs";
import {NgClass} from "@angular/common";

@Component({
  selector: 'app-side-nav',
  standalone: true,
  imports: [
    NgClass
  ],
  templateUrl: './side-nav.component.html',
  styleUrl: './side-nav.component.scss'
})
export class SideNavComponent {
  selectedTab$ = signal<SidebarTabs>('buy');

  setTab(tab: SidebarTabs) {
    this.selectedTab$.set(tab);
  }
}
