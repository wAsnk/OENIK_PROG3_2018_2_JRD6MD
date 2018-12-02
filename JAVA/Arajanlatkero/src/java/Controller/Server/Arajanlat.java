/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller.Server;

import Controller.Autotarolo;
import Model.Auto;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Chris
 */
public class Arajanlat extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");        
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        //processRequest(request, response);
        handleRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>
    
    public void handleRequest(HttpServletRequest req, HttpServletResponse res) throws IOException {

        PrintWriter out = res.getWriter();
        res.setContentType("text/plain");
        String paramOne = "carname";
        String paramTwo = "price";
        String paramThree = "name";
        String carname = req.getParameter(paramOne);
        String stringprice = req.getParameter(paramTwo);
        String name = req.getParameter(paramThree);
        
//        out.write(carname);
//        out.write(String.valueOf(price));
        int price = Integer.parseInt(stringprice);
        int maxPrice = price + 1000;
        int minPrice = price - 1000;
        if (minPrice < 0) {
            minPrice = 0;            
        }
        Random rnd = new Random();        
        Autotarolo at = new Autotarolo(); 
        
        for (int i = 0; i < 5; i++) {
            int newPrice = rnd.nextInt(maxPrice + 1 - minPrice) + minPrice;
            at.addAuto(new Auto(carname, newPrice));            
        }

        if (carname == null || carname.equals("")) {
            out.write("Parameter " + paramOne + " not found\n");   
        }
        if (stringprice == null || stringprice.equals(""))
        {
            out.write("Parameter " + paramTwo + " not found\n");
        }
        if (name == null || name.equals(""))
        {
            out.write("Parameter " + paramThree + " not found");
        }
        else
        {  
            //<name><%= session.getAttribute("name") %></name>
            res.setContentType("application/xml");
            out.write("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            out.write("<cars>");
            for (Auto auto : at.getTarolo()) {
                out.write("<car>");
                out.write("<carbrand>" + auto.getAutonev() + "</carbrand>");
                out.write("<name>" + name + "</name>");
                out.write("<price>" + auto.getAr() + "</price>");
                out.write("</car>");
            }
            out.write("</cars>");
        }

        out.close();

    }
}
