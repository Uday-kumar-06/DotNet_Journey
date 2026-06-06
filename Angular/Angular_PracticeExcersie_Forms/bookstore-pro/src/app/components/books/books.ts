import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable, Subscription } from 'rxjs';

import { DataService } from '../../services/data';
import { Book } from '../../models/book';
import { BookCard } from '../book-card/book-card';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, BookCard],
  templateUrl: './books.html',
  styleUrl: './books.css'
})
export class Books implements OnInit, OnDestroy {

  books: Book[] = [];

  books$!: Observable<Book[]>;

  subscription!: Subscription;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {

    // Async Pipe

    this.books$ = this.dataService.getBooks();

    // Manual Subscribe

    this.subscription =
      this.dataService.getBooks()
      .subscribe(data => {
        this.books = data;
      });
  }

  ngOnDestroy(): void {

    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}