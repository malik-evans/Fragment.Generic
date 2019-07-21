import {Component, OnInit} from '@angular/core';
import {EntityCache, EntityCollectionService, EntityServices} from "@ngrx/data";
import {Store} from "@ngrx/store";

interface User {
  id: string;
  name: string;
}

@Component({
  selector: 'app-root',
  template: `<h1>{{ title }}</h1>`,
})
export class AppComponent implements OnInit {
  title = 'integration';

  userService: EntityCollectionService<User>;

  constructor(
    private store: Store<EntityCache>,
    private services: EntityServices) {
    this.userService = services.getEntityCollectionService<User>('User')
  }

  ngOnInit(): void {
    var user = <User>{ id: "1", name: "Mia"};

    this.store.subscribe( val => console.log({ state: val }));
    this.userService.add(user);
    this.userService.addOneToCache(user);
  }
}
