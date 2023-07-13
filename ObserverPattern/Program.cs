// See https://aka.ms/new-console-template for more information

using ObserverPattern;

Vip osammot = new Vip("Osammot");

//Creo 2 osservatori
Osservatore o1 = new Osservatore("Follower1");
Osservatore o2 = new Osservatore("Follower2");

osammot.addOsservatore(o1);
osammot.addOsservatore(o2);
Thread.Sleep(3000);
osammot.Notifica("informatica");
Thread.Sleep(3000);
osammot.Notifica("matematica");

osammot.removeOsservatore(o2);
Thread.Sleep(3000);
osammot.Notifica("algebra");