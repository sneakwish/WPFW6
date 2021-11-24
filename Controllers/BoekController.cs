using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WPFW6._1.Models;


public class BoekController : Controller{

    public ViewResult Index(){
        return View(Boek.Boeken);
    }    
     
    public IActionResult aantal(string id){
        ViewData["aantal"] = Boek.Boeken.Count(boek=>boek.Auteur == id);
        ViewData["Auteur"] = id;
        return View();
    } 
    public IActionResult genre(string id){
        Boek boek = Boek.Boeken.Where(boek=>boek.ISBN == id).SingleOrDefault();
        var yo = Boek.Boeken;
        return View(boek);
    }

      public IActionResult zoek(string id){
        List<string> auteurs = Boek.Boeken
        .Where(boek=>boek.Auteur.StartsWith(id))
        .GroupBy(boek=>boek.Auteur)
        .Select(g=>g.Key).ToList();
        return View(auteurs);
    }

    [HttpGet]
    public IActionResult create(){
        return View();
    }

    [HttpPost]
    public IActionResult create(String ISBN, String Auteur, String Titel, String Genre){
        Boek.create(ISBN, Titel, Genre, Auteur);
        System.Console.WriteLine(ISBN+Auteur+Titel+Genre);
        Boek.Boeken.Append(new Boek("999999999999", "W99999999ó", "D99999sie", "act78978879897e"));

        

        return View(Boek.Boeken);
    }
   
}


