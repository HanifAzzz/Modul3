<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organisasi.aspx.cs" Inherits="OrganisasiWeb.Organisasi" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Manajemen Organisasi Mahasiswa</title>
</head>

<body>

<form id="form1" runat="server">

<h1>ORGANISASI KEL 38</h1>

Nama
<asp:TextBox ID="txtNama" runat="server"></asp:TextBox>
<br /><br />

NIM
<asp:TextBox ID="txtNIM" runat="server"></asp:TextBox>
<br /><br />

Angkatan
<asp:TextBox ID="txtAngkatan" runat="server"></asp:TextBox>
<br /><br />

Bidang
<asp:DropDownList ID="ddlBidang" runat="server"></asp:DropDownList>
<br /><br />

<asp:Button ID="btnTambah" runat="server" Text="Tambah Mahasiswa" OnClick="btnTambah_Click" />

<br /><br />

<asp:GridView ID="GridView1" runat="server"
AutoGenerateColumns="false"
DataKeyNames="id_mahasiswa"
OnRowEditing="GridView1_RowEditing"
OnRowUpdating="GridView1_RowUpdating"
OnRowCancelingEdit="GridView1_RowCancelingEdit"
OnRowDeleting="GridView1_RowDeleting">

<Columns>

<asp:BoundField DataField="id_mahasiswa" HeaderText="ID" ReadOnly="true" />
<asp:BoundField DataField="Nama" HeaderText="Nama" />
<asp:BoundField DataField="NIM" HeaderText="NIM" />
<asp:BoundField DataField="Angkatan" HeaderText="Angkatan" />
<asp:BoundField DataField="NamaBidang" HeaderText="Bidang" />

<asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />

</Columns>

</asp:GridView>

</form>

</body>
</html>