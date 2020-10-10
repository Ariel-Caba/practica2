

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registro_alumno.aspx.cs" Inherits="presentacion.registro_alumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <p class="">Carnet</p>         
            <asp:TextBox ID="TxtCarnet" runat="server"></asp:TextBox>
        <asp:Label ID="l_carnet" runat="server"></asp:Label>
        <br />
        <br />
        <p>Primer Nombre</p>
        <asp:TextBox ID="TxtNombre1" runat="server"></asp:TextBox>            
        <asp:Label ID="l_nombre1" runat="server"></asp:Label>
        <br />
        <br />
        
        <p>Segundo Nombre</p>            
        <asp:TextBox ID="TxtNombre2" runat="server"></asp:TextBox>            
        <asp:Label ID="l_nombre2" runat="server"></asp:Label>
        <br />
        <br />
        
        <p>Primer Apellido</p>            
        <asp:TextBox ID="TxtApellido1" runat="server"></asp:TextBox>            
        <asp:Label ID="l_apellido1" runat="server" ></asp:Label>
        
        <br />
        <br />
        <p>Segundo Apellido</p>           
        <asp:TextBox ID="TxtApellido2" runat="server"></asp:TextBox>
            
        <asp:Label ID="l_apellido2" runat="server"></asp:Label>
           
    <br />
    <br />
    <br />
    
    <div class ="container">
        <section class="main row">
            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
        
                <p>Año</p>
        <asp:TextBox ID="TxtAño" runat="server"></asp:TextBox>
                </div>
            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
        <p>Mes</p>
        <asp:TextBox ID="Txtmes" runat="server"></asp:TextBox>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
        <p>Dia</p>
        <asp:TextBox ID="Txtdia" runat="server"></asp:TextBox>
            </div>

            
        </section>
        <asp:Label ID="l_fecha" runat="server"></asp:Label>
        <br />
        <div>
                <asp:RadioButton ID="RB_alumno" runat="server" Checked="true" Text="Alumno" GroupName="ScanOnStartupRadio" />
                <asp:RadioButton ID="RB_maestro" runat="server" Checked="false" Text="Profesor" GroupName="ScanOnStartupRadio" />
            </div>
        

    <br />
        <div class="container">
                
            <section class="main row">
                
               <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 row justify-content-center">
                <asp:Button ID="Btn_registro" CssClass="btn btn-primary" OnClick="registro" runat="server" Width="75px" Text="Guardar" />
                  
                </div>
                <br />
                <br />
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="Btn_buscar"   CssClass="btn btn-success" OnClick="Buscar" runat="server" Width="75px" Text="Buscar" />
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
                <asp:Button ID="Button1" CssClass="btn btn-danger" OnClick="btnlimpiar" runat="server" Width="75px" Text="limpiar" />
                </div>
            </section>
        </div>
        
    </div>
   </div>

      <br />
    <br />

    <p>Alumnos</p>
    <div class="container">    
        <div class="box-body table-responsive">
            <table class="table table-info table-striped table-bordered table-hover">
                <thead>
                <tr>
                    <th>Carnet</th>
                    <th>Primer Nombre</th>
                    <th>Segundo Nombre</th>
                    <th>primer apellido</th>
                    <th>Segundo apellido</th>
                    <th>fecha nacimiento</th>
                    <th>Edad</th>
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="Content_tabla_alumno" runat="server" />
                </tbody>
            </table>
        </div>
    </div>

    <p>profesores</p>
    <div class="container">    
        <div class="box-body table-responsive">
            <table class="table table-info table-bordered table-hover">
                <thead>
                <tr>
                    <th>Carnet</th>
                    <th>Primer Nombre</th>
                    <th>Segundo Nombre</th>
                    <th>primer apellido</th>
                    <th>Segundo apellido</th>
                    <th>fecha nacimiento</th>
                    <th>Edad</th>
                    
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="Content_tabla_profesor" runat="server" />
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript" src="/dis/dis_tabla.js"></script>

</asp:Content>
