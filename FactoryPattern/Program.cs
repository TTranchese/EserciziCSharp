// See https://aka.ms/new-console-template for more information 
using FactoryPattern;
//Cosi' non va bene
/*Cerchio c1 = new Cerchio(1);
Rettangolo r1 = new Rettangolo(2);
Quadrato q1 = new Quadrato(3);*/

ShapeFactory shapeFactory = new ShapeFactory();
Cerchio? c1 = (Cerchio)shapeFactory.getShape(ShapeFactory.TipoFigura.Cerchio)!;