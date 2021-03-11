<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ServiceBookingList.aspx.cs" Inherits="VehicleService.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>Service Booking List</h1>
                    <hr />
                    <br />
                    <div>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <asp:HyperLink ID="hlServiceBookingAdd" runat="server" Text="Add New Book" NavigateUrl="~/ServiceBookingAddEdit.aspx" CssClass="btn btn-primary" />
                    </div>
                    <br /><hr />
                    <asp:GridView ID="gvServiceBooking" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" OnRowCommand="gvServiceBooking_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="ServiceBookingID" HeaderText="ID" />
                            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                            <asp:BoundField DataField="CustomerNo" HeaderText="Customer No" />
                            <asp:BoundField DataField="VehicleName" HeaderText="Vehicle Name" />
                            <asp:BoundField DataField="BookingSlotTime" HeaderText="Booking Slot Time" />
                            <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" CssClass="btn btn-info" Text="Edit" aria-hidden="true" runat="server" NavigateUrl='<%#"~/ServiceBookingAddEdit.aspx?ServiceBookingID=" + Eval("ServiceBookingID").ToString().Trim() %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ServiceBookingID") %>' CssClass="btn btn-warning" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
