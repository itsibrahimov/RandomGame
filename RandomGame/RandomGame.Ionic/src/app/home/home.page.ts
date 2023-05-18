import { Component } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import {HttpClient} from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: true,
  imports: [IonicModule],
})
export class HomePage {
  GameModelList:Array<GameModel>=[];
  constructor(http:HttpClient) 
  {
    
    http.get<Array<GameModel>>('https://localhost:44362/Game/GetGames').subscribe((data)=>{
      this.GameModelList=data;
    })
  }
}
class Image{
  gameID:number=0;
  ImageURL:string="";
}
class GameModel {
   description:string="";
   gameID:number=0;
   gameName:string="";
   images:Array<Image>=[];
    price:number=0;
    stock:number=0;
}
