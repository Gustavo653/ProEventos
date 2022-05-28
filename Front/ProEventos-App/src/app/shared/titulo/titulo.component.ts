import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo: string | undefined;
  @Input() iconClass: string = 'fa fa-user';
  @Input() subTitulo: string = 'Desde 2021';
  @Input() botaoListar: boolean = false;
  constructor() { }

  ngOnInit() {
  }

}
