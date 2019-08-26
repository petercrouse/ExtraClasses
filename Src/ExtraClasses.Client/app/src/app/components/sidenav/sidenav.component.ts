import { Component, OnInit, NgZone, ViewChild } from '@angular/core';

const SMALL_WIDTH_BREAKPOINT = 720;

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  private mediaMatcher: MediaQueryList = matchMedia(`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`);
  isDarkTheme = false;

  constructor() {}

  ngOnInit() {
  }

  toggleTheme() {
    this.isDarkTheme = !this.isDarkTheme;
  }

  isScreenSmall(): boolean {
    return this.mediaMatcher.matches;
  }
}
