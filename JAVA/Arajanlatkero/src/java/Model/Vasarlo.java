/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import Controller.Autotarolo;

/**
 *
 * @author Chris
 */
public class Vasarlo {
    String nev;
    Autotarolo tarolo;

    public Vasarlo(String nev, Autotarolo tarolo) {
        this.nev = nev;
        this.tarolo = tarolo;
    }

    public String getNev() {
        return nev;
    }    
    
}
