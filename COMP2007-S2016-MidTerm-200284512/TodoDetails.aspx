<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200284512.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <div class="col-md-offset-3 col-md-6">
             <h1>Todo Details</h1>
             <div class="form-group">
                 <label class="control-label" for="TodoNameTextBox">Todo Name</label>
                 <asp:TextBox ID="TodoNameTextBox" runat="server" CssClass="form-control" placeholder="Todo Name" required="true"></asp:TextBox>
                 <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Todo Name is required" ControlToValidate="TodoNameTextBox"></asp:RequiredFieldValidator>
             </div>
             <div class="form-group">
                 <label class="control-label" for="NotesTextBox">Todo Notes</label>
                 <asp:TextBox ID="NotesTextBox" TextMode="MultiLine" Rows="3" Columns="3" runat="server" CssClass="form-control" placeholder="Todo Notes"></asp:TextBox>
             </div>
             <div class="form-group">
                 <asp:CheckBox ID="CheckBox" runat="server" Text=" Completed" />
             </div>
             <div class="text-right">
                 <a href="TodoList.aspx" class="btn btn-warning btn-lg">Cancel</a>
                 <asp:Button runat="server" CssClass="btn btn-primary btn-lg" ID="SaveButton" Text="Save" OnClick="SaveButton_Click" />
             </div>
         </div>
     </div>
</asp:Content>
