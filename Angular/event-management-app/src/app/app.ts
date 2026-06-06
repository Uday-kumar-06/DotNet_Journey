import { Component } from '@angular/core';
import { EventList } from './components/event-list/event-list';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EventList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}
