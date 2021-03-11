<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ServiceBookingAddEdit.aspx.cs" Inherits="VehicleService.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblPageHeader" runat="server" /><hr />
                </h1>
                <asp:Label runat="server" ID="lblMessage" />
            </div>
        </div>


        <div class="form-group row">
            <label for="lblCustomerName" class="col-sm-2 col-form-label">Customer Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtCustomerName" CssClass="form-control" placeholder="Enter CustomerName" />
                <asp:RequiredFieldValidator runat="server" ID="rfvCustomerName" ControlToValidate="txtCustomerName" Display="Dynamic" ErrorMessage="Enter CustomerName" ForeColor="Red" ValidationGroup="rfvBooking" />
            </div>
        </div>

        <div class="form-group row">
            <label for="lblCustomerNo" class="col-sm-2 col-form-label">Customer Mobile No.</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtCustomerNo" CssClass="form-control" placeholder="Enter txtCustomerNo" />
                <asp:RequiredFieldValidator runat="server" ID="rfvCustomerNo" ControlToValidate="txtCustomerNo" Display="Dynamic" ErrorMessage="Enter txtCustomerNo" ForeColor="Red" ValidationGroup="rfvBooking" />
            </div>
        </div>

        <div class="form-group row">
            <label for="lblRegistrationNo" class="col-sm-2 col-form-label">Registration No</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtRegistrationNo" CssClass="form-control" placeholder="Enter RegistrationNo" />
                <asp:RequiredFieldValidator runat="server" ID="rfvRegistrationNo" ControlToValidate="txtRegistrationNo" Display="Dynamic" ErrorMessage="Enter RegistrationNo" ForeColor="Red" ValidationGroup="rfvBooking" />
            </div>
        </div>

        <div class="form-group row">
            <label for="lblVehicle" class="col-sm-2 col-form-label">Vehicle</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddlVehicle" CssClass="form-control">
                    <asp:ListItem Selected="false" runat="server" InitialValue="-1" Text="--Select 2-Vehicle--"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvVehicle" ControlToValidate="ddlVehicle" Display="Dynamic" ErrorMessage="Select Vehicle" ForeColor="Red" ValidationGroup="rfvBooking" />
            </div>
            <label for="lblBookingSlot" class="col-sm-2 col-form-label">Booking Time Slot</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddlBookingSlot" CssClass="form-control" OnSelectedIndexChanged="ddlBookingSlot_SelectedIndexChanged">
                    <asp:ListItem Selected="false" runat="server" InitialValue="-1" Text="--Select Booking Slot--"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvBookingSlot" ControlToValidate="ddlBookingSlot" Display="Dynamic" ErrorMessage="Select BookingSlot" ForeColor="Red" ValidationGroup="rfvBooking" />
            </div>
        </div>

            <div class="form-group row">
                <div class="col-sm-10"></div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success pull-right" OnClick="btnSave_Click" />
                    <asp:HyperLink ID="hlCancel" runat="server" Text="Cancel" NavigateUrl="~/ServiceBookingList.aspx" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
</asp:Content>
