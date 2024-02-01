<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="container">
    <div class="row">
        <div class="col-sm-6 col-md-4 col-md-offset-4">
            <h1 class="text-center login-title">SISTEMA DE LOGISTICA</h1>
            <div class="account-wall">
                <img class="profile-img" src="<%=ResolveClientUrl("Images/login-avatar.png")%>"
                    alt="">
               
                 <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="Usuario" required autofocus></asp:TextBox>
                 <asp:TextBox ID="TextPass" runat="server" type="password" class="form-control" placeholder="Contraseña" required  ></asp:TextBox>
             
           
             <asp:Button ID="btLogin" runat="server" class="btn btn-lg btn-primary btn-block"  Text="Iniciar Sesión" OnClick="btLogin_Click" />
                     <asp:label ID="lblMensaje" runat="server" class="form-control"  Visible ="False" ForeColor="Black" BackColor="Red" Font-Bold="True"  ></asp:label>
              
               
                
            </div>
            
        </div>
    </div>
</div>



   
  
  
</asp:Content>