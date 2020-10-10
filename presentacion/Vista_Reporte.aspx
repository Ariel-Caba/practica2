<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vista_Reporte.aspx.cs" Inherits="presentacion.Vista_Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <div class="container">
        <p>Alumnos con cero cursos asignados</p>
        <div class="box-body table-responsive">
            <table class="table table-info table-striped table-bordered table-hover">
                <thead>
                <tr>
                    <th style="width:10%">Carnet</th>
                    <th style="width:50%">Nombre Completo</th> 
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="tabla_CeroAsignados" runat="server" />
                </tbody>
            </table>
        </div>
           <hr />
          <p>Alumnos con al menos un curso asignado</p>
        <div class="box-body table-responsive">
            <table class="table table-info table-striped table-bordered table-hover">
                <thead>
                <tr>
                    <th style="width:10%">Carnet</th>
                    <th style="width:50%">Nombre Completo</th>                    
                    <th style="width:50%">Cantidad de cursos</th>
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="tabla_UnoAsignados" runat="server" />
                </tbody>
            </table>
        </div>

       <p>cursos con sus maestros</p>
        <div class="box-body table-responsive">
            <table class="table table-info table-striped table-bordered table-hover">
                <thead>
                <tr>
                    <th style="width:10%">Cod_curso</th>
                    <th style="width:50%">Nombre_curso</th>                    
                    <th style="width:50%">nombre_profesor</th>
                    <th style="width:50%">cantidad_de_alumnos</th>
                </tr>
                    </thead>
                <tbody>                    
                    <asp:PlaceHolder ID="Content_curso_maestro_alumno" runat="server" />
                </tbody>
            </table>
        </div>
    </div>
    
</asp:Content>
