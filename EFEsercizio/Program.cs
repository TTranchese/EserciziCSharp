using EFEsercizio.Models;

BibliotecaContext ctx = new BibliotecaContext();

Libri libri = new Libri("oriva", "fasdf", "asdf", 2001, 1, 1);

ctx.Libris.Add(libri);
ctx.SaveChanges();
