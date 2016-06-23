<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200284512.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <div class="col-md-offset-1 col-md-10">
             <h1>Todo List</h1>
             <asp:GridView runat="server" ID="TodoGridView" CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="TodoGridView_RowDeleting" DataKeyNames="TodoID" >
                 <Columns>
                     <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="true" />
                     <asp:BoundField DataField="TodoName" HeaderText="Todo Name" Visible="true" />
                     <asp:BoundField DataField="TodoNotes" HeaderText="Todo Notes" Visible="true" />
                     <asp:CheckBoxField DataField="Completed" HeaderText="Completed" Visible="true" />
                     <asp:HyperLinkField HeaderText="Edit" Text="Edit" runat="server" ControlStyle-CssClass="btn btn-primary" NavigateUrl="~/TodoDetails.aspx.cs" />
                     <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" ButtonType="Link" />
                 </Columns>
             </asp:GridView>
         </div>
     </div>
</asp:Content>
