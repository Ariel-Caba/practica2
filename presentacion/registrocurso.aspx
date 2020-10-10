<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registrocurso.aspx.cs" Inherits="presentacion.registrocurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
          <div class="container">
        <p>Cod_curso</p>
        <asp:TextBox ID="txtCodcurso" runat="server"></asp:TextBox>            
        <asp:Label ID="l_Codcurso" runat="server"></asp:Label>
        <br />
        <br />

        <p>Nombre Curso</p>
        <asp:TextBox ID="TxtNombre" runat="server" Width="200px"></asp:TextBox>            
        <asp:Label ID="l_nombre" runat="server"></asp:Label>
        <br />
        <br />
        
        <p>Descripcion</p>            
        <asp:TextBox ID="TxtDescripcion" runat="server" MaxLength="100" Width="600px"></asp:TextBox>            
        <asp:Label ID="l_Descripcion" runat="server"></asp:Label>
        </div>
    <br />
    <br />
    
    <div class ="container">      
        

    <br />
        <div class="container">
                
            <section class="main row">
                
               <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 row justify-content-center">
                <asp:Button ID="Btn_registro" CssClass="btn btn-primary" OnClick="registroClick" runat="server" Width="75px" Text="Guardar" />
                </div>
                <br />
                <br />
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="Btn_buscar"   CssClass="btn btn-success" OnClick="BuscarClick" runat="server" Width="75px" Text="Buscar" />
                <br />
                </div>
                <br />
                <br />
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="Btn_editar"   CssClass="btn btn-warning" OnClick="btn_actualizarClick" runat="server" Width="75px" Text="Actualizar" />
                </div>
                <br />
                <br />
                
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="Btn_eliminar" CssClass="btn btn-danger" OnClick="eliminarClick" runat="server" Width="75px" Text="Eliminar" />
                </div>
                <br />
                <br />
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="Button1" CssClass="btn btn-danger" OnClick="btnlimpiarClick" runat="server" Width="75px" Text="limpiar" />
                </div>
            </section>
        </div>
       
    </div>
   </div>

      <br />
    <br />

    <p>Cursos</p>
    <div class="container">    
        <div class="box-body table-responsive">
            <table class="table table-info table-striped table-bordered table-hover">
                <thead>
                <tr>
                    <th style="width:5%">Cod_curso</th>
                    <th style="width:25%">Nombre</th>
                    <th style="width:70%">Descripcion</th>                    
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="Content_tabla_curso" runat="server" />
                </tbody>
            </table>
        </div>
    </div>    

    <script type="text/javascript" src="/dis/dis_tabla.js"></script>

</asp:Content>
