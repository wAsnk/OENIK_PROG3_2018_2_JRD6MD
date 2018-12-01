<%@page import="Model.Auto"%><%@page import="Controller.Autotarolo"%><% Autotarolo at = (Autotarolo) session.getAttribute("autok"); %><%@page contentType="application/xml" pageEncoding="UTF-8"%><?xml version="1.0" encoding="utf-8"?>
<cars>
    <% for (Auto auto : at.getTarolo()) {%><car>
        <carbrand><%=auto.getAutonev()%></carbrand>
        <name><%= session.getAttribute("name") %></name>
        <price><%=auto.getAr()%></price>
    </car><%}%>      
</cars>