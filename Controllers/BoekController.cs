using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WPFW6._1.Models;


public class BoekController : Controller{

// public static List<Boek> boekenLijst = new List<Boek>();

    public static List<Boek> Boekelijst(){
        List<Boek> boeken3 = Boek.Boeken.ToList();
        return boeken3;
    }


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
        List<Boek> nieuweLijst = Boekelijst();
        nieuweLijst.Add(new Boek(ISBN, Auteur, Titel, Genre));

        Boek.Boeken = nieuweLijst;
        return Redirect("index");
    }

    [HttpGet]
    public IActionResult delete(){
        return View();
    }

    [HttpPost]
    public IActionResult delete(String ISBN){
        List<Boek> nieuweLijst = Boekelijst();

        Boek boek6 = nieuweLijst.Where(boek=>boek.ISBN == ISBN).SingleOrDefault();
  
        nieuweLijst.Remove(boek6);

        Boek.Boeken = nieuweLijst;

        return Redirect("index");
    }


    [HttpGet]
    public IActionResult update(String ISBN){
        Boek boek6 = Boekelijst().Where(boek=>boek.ISBN == ISBN).SingleOrDefault();
        return View(boek6);
    }

    [HttpPost]
    public IActionResult update(String ISBN, String Auteur, String Titel, String Genre){

        Boek boek6 = Boekelijst().Where(boek=>boek.ISBN == ISBN).SingleOrDefault();
        boek6.ISBN = ISBN;
        boek6.Auteur = Auteur;
        boek6.Titel = Titel;
        boek6.Genre = Genre;
        
        return Redirect("index");
    }


   
}


