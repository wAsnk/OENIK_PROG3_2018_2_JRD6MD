/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller.Server;

import Controller.Autotarolo;
import Model.Auto;
import Model.Vasarlo;
import java.io.IOException;
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
public class OfferServlet extends HttpServlet {

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
//        try (PrintWriter out = response.getWriter()) {
//            /* TODO output your page here. You may use following sample code. */
//            out.println("<!DOCTYPE html>");
//            out.println("<html>");
//            out.println("<head>");
//            out.println("<title>Servlet OfferServlet</title>");            
//            out.println("</head>");
//            out.println("<body>");
//            out.println("<h1>Servlet OfferServlet at " + request.getContextPath() + "</h1>");
//            out.println("</body>");
//            out.println("</html>");
//        }
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
        processRequest(request, response);
        request.setCharacterEncoding("UTF8");
        response.setCharacterEncoding("UTF8");
        
        HttpSession session = request.getSession();
        String nev = request.getParameter("nev");
        session.setAttribute("name", nev);
        String carBrand = request.getParameter("carbrand");
        String priceString = request.getParameter("price");
        int price = Integer.parseInt(priceString);
        
        int maxPrice = price + 1000;
        int minPrice = price - 1000;
        Random rnd = new Random();
        
        Autotarolo at = new Autotarolo();
        session.setAttribute("autok", at);
        for (int i = 0; i < 5; i++) {
            int newPrice = rnd.nextInt(maxPrice + 1 - minPrice) + minPrice;
            at.addAuto(new Auto(carBrand, newPrice));            
        }
        response.sendRedirect(response.encodeRedirectURL("xml_file.jsp"));
        
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
        
        request.setCharacterEncoding("UTF8");
        response.setCharacterEncoding("UTF8");
        
        HttpSession session = request.getSession();
        
        Autotarolo at = null;
//        <form method="POST" action="OfferServlet">
//            Name: <input type="text" name="nev"> <br>
//            Car brand: <input type="text" name="carbrand"> <br>
//            Full price: <input type="text" name="price"> <br>
//            <input type="submit" value="Get offer">
//        </form>
                    
        String nev = request.getParameter("nev");
        String carBrand = request.getParameter("carbrand");
        String price = request.getParameter("price");
        
        if (session.getAttribute("autok") != null) {
            at = (Autotarolo) session.getAttribute("autok");
        }
        else {
            at = new Autotarolo();
        }
        
        Vasarlo v = new Vasarlo(nev,at);
        
        session.setAttribute("vasarlo", v);
        session.setAttribute("autok", at);
        response.sendRedirect(response.encodeRedirectURL("index.jsp"));
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

}
