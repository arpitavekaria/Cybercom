<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VehicleAddEdit.aspx.cs" Inherits="VehicleService.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top:50px;">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <asp:Label ID="lblPageHeader" runat="server" /><hr />
                    </h1>
                    <asp:label runat="server" ID="lblMessage" />
                </div>
            </div>
             <div class="form-group row">
                 <label for="lblVehicleName" class="col-sm-2 col-form-label">Vehicle Name</label>
                 <div class="col-sm-10">
                     <asp:TextBox runat="server" ID="txtVehicleName" ToolTip="Please FillOut This Field" CssClass="form-control" placeholder="Enter 2-Vehicle Name" />
                     <asp:RequiredFieldValidator runat="server" ID="rfvVehicleName" ControlToValidate="txtVehicleName" Display="Dynamic" ErrorMessage="Please Enter Vehicle Name" ForeColor="Red" ValidationGroup="rfvVehicle" /> 
                 </div>
             </div>

             <div class="form-group row">
                 <div class="col-sm-10"></div>
                 <div class="col-sm-2 pull-right">
                     <asp:Button runat="server" ID="btnSave" Text="Save"  CssClass="btn btn-success pull-right" OnClick="btnSave_Click"/>
                     <asp:HyperLink ID="hlCancel" runat="server" Text="Cancel" NavigateUrl="~/VehicleList.aspx" CssClass="btn btn-danger" />
                 </div>
             </div>
         </div>
</asp:Content>
