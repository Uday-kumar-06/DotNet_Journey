import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  getBooks(): Observable<Book[]> {

    return of([
      {
        id: 1,
        title: 'Angular Mastery',
        price: 999,
        publicationDate: '2025-01-15',
        description:
          'Complete Angular guide from beginner to advanced level.'
      },
      {
        id: 2,
        title: 'TypeScript Deep Dive',
        price: 799,
        publicationDate: '2024-05-20',
        description:
          'Learn TypeScript concepts and practical examples.'
      },
      {
        id: 3,
        title: 'RxJS Essentials',
        price: 699,
        publicationDate: '2023-08-10',
        description:
          'Master Observables Subjects and Operators in RxJS.'
      }
    ]);
  }
}