<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asingacionestudiante.aspx.cs" Inherits="presentacion.Asingacionestudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">                
            <section class="main row">      
                <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                    <div>
                        <p class="">Carnet Alumno</p>         
                        <asp:TextBox ID="TxtCarnetalumno" runat="server"></asp:TextBox>
                        <asp:Label ID="l_carnet" runat="server"></asp:Label>
                    </div>

                    <br />
                    <asp:Label ID="L_profesion" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="L_nombrecompleto" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="L_fechanacimiento" runat="server"></asp:Label>
                    <br />
                    <br />
                    <div>
                        <p class="">Codigo curso</p>         
                        <asp:TextBox ID="txtcod_curso" runat="server"></asp:TextBox>
                        <asp:Label ID="L_curso" runat="server"></asp:Label>
                    </div>
                    <br />
                    <asp:Label ID="L_nombreCurso" runat="server"></asp:Label>
                    <br />
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6"> 
                     <asp:Label ID="tablatitulo2" runat="server" Text="Cursos Asignados"></asp:Label>
                    <div class="box-body table-responsive">
                        <table class="table table-info table-striped table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th style="width:10%">Cod. curso</th>
                                    <th style="width:50%">Nombre Curso</th>
                                </tr>
                            </thead>
                            <tbody>                    
                                <asp:PlaceHolder ID="content_reporte" runat="server" />
                            </tbody>
                        </table>
                    </div>
                </div>
            </section>
   </div>
    <br />
    <br />  
    <br />
    <br />



     <div class="container">                
            <section class="main row">                
               <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 row justify-content-center">
                <asp:Button ID="Btn_registro" CssClass="btn btn-success" OnClick="BuscarClick" runat="server" Width="75px" Text="Buscar" />
                </div>
                <br />
                <br />
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="Btn_buscar"   CssClass="btn btn-primary" OnClick="AsignarClick" runat="server" Width="75px" Text="Asignar" />
                
                </div>
                <br />
                <br />
                
                
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="Btn_eliminar" CssClass="btn btn-danger" OnClick="DesAsignarClick" runat="server" Width="75px" Text="DesAsignar" />
                </div>
                <br />
                <br />
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 row justify-content-center">
                <asp:Button ID="Button1" CssClass="btn btn-outline-warning" OnClick="LimpiarClick" runat="server" Width="75px" Text="limpiar" />
                </div>
                
            </section>
        </div>
    <hr />
    <asp:Label ID="L_titulotabla" runat="server" Text="Alumnos"></asp:Label>
    <div class="container">  
        <section class="main row">                
               
                <br />
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="btnalumnos"   CssClass="btn btn-outline-success" OnClick="Alumnos_entabla_Click" runat="server" Width="75px" Text="Alumnos" />
                
                </div>
                <br />
                <br />
                
                
                <div class="col-xs-12 col-md-6 col-lg-6 row justify-content-center">
                <asp:Button ID="btnprofesores" CssClass="btn btn-outline-success" OnClick="Profesores_entablaClick" runat="server" Width="75px" Text="Profesores" />
                </div>
                <br />
                
                
            </section>
        <div class="box-body table-responsive">
            <table class="table table-info table-striped table-bordered table-hover">
                <thead>
                <tr>
                    <th style="width:10%">Carnet</th>
                    <th style="width:50%">Nombre Completo</th>                    
                    <th style="width:10%">Fecha nacimiento</th>
                    <th style="width:10%">Edad</th>
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="Content_tabla_alumno" runat="server" />
                </tbody>
            </table>
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
                    <th style="width:15%">Cod_curso</th>
                    <th style="width:85%">Nombre</th>                    
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="Content_tabla_curso" runat="server" />
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
