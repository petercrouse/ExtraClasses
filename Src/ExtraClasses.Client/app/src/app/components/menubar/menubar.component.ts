import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-menubar',
  templateUrl: './menubar.component.html',
  styleUrls: ['./menubar.component.scss']
})
export class MenubarComponent implements OnInit {
  @Output() toggleSidenav = new EventEmitter<void>();
  @Output() toggleTheme = new EventEmitter<void>();

  constructor() {}

  ngOnInit() {}
}
