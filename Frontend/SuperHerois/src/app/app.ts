import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Herois } from "./components/herois/herois";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Herois],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'SuperHerois';
}
