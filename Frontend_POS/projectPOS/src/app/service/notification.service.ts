import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private hubConnection!: signalR.HubConnection;

  constructor() { }

  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5045/notificationHub') // Promenjen URL
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('SignalR connection started'))
      .catch(err => console.error('Error while starting SignalR connection: ' + err));
  }

  public addUpdateListener(callback: (message: string) => void) {
    this.hubConnection.on('ReceiveUpdate', (message: string) => {
      callback(message);
    });
  }

  public sendUpdate(productUpdate: any) {
    this.hubConnection.invoke('SendUpdate', productUpdate)
      .catch(err => console.error('Error sending update: ' + err));
  }
}

