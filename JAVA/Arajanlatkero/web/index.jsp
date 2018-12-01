<%-- 
    Document   : index
    Created on : 2018.12.01., 16:58:55
    Author     : Chris
--%>

<%@page import="Controller.Autotarolo"%>
<%@page import="Model.*"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<%
    Autotarolo at = (Autotarolo) session.getAttribute("autok");
    if (at == null) {
        at = new Autotarolo();
        session.setAttribute("autok", at);            
        }
    
    Vasarlo vasarlo = (Vasarlo) session.getAttribute("vasarlo");
    
%>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Offer request</title>
    </head>
    <body>        
        <% if (vasarlo == null) { %>
        <h1>Offer request</h1>
        <form method="POST" action="OfferServlet">
            Name: <input type="text" name="nev"> <br>
            Car brand: <input type="text" name="carbrand"> <br>
            Full price: <input type="text" name="price"> <br>
            <input type="submit" value="Get offer">
        </form>
        <% } else { %>
        <h2>Cars around this price</h2>
        <br><a href="NewOffer">New Request</a>
        <br>
        <% for (Auto auto : at.getTarolo()) { %>
        <strong><%= auto.getAutonev() %> => <%= auto.getAr() %></strong>
        <hr>
        <% } 
        } %>
    </body>
</html>
