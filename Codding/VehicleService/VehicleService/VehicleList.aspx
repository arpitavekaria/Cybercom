<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VehicleList.aspx.cs" Inherits="VehicleService.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>Vehicle List</h1><hr />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" ></asp:Label>
                    <asp:HyperLink ID="hlVehicleAdd" runat="server" Text="Add New Vehicle" NavigateUrl="~/VehicleAddEdit.aspx" CssClass="btn btn-primary" />
                    
                    

                    <br /><hr />

                    <asp:GridView ID="gvVehicle" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" OnRowCommand="gvVehicle_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="VehicleID" HeaderText="ID" />
                            <asp:BoundField DataField="VehicleName" HeaderText="Vehicle Name" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" CssClass="btn btn-info" Text="Edit" aria-hidden="true" runat="server" NavigateUrl='<%#"~/VehicleAddEdit.aspx?VehicleID=" + Eval("VehicleID").ToString().Trim() %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("VehicleID") %>' CssClass="btn btn-warning" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                            
                        </Columns>
                    </asp:GridView>

                </div>
                
            </div>
        </div>
    </div>
    
</asp:Content>
