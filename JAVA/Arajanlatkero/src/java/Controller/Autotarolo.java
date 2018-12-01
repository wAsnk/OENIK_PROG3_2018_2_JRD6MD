/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Model.Auto;
import java.util.ArrayList;

/**
 *
 * @author Chris
 */
public class Autotarolo {
    
    private static ArrayList<Auto> tarolo = new ArrayList<>();
    

    public Autotarolo() {
    }
    
    public ArrayList<Auto> getTarolo() {
        return tarolo;
    }

    
    public void addUgyfel(Auto auto){
        if (!tarolo.contains(auto)) {
            tarolo.add(auto);
        }
    }
}
