Imports System.Data.SqlClient

Public Class pencarianBuku

    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand
    Sub tabelBuku()
        Call login.koneksi()
        Da = New SqlDataAdapter("select * from buku where judul='" & TextBox1.Text & "' ", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "buku")
        DataGridView1.DataSource = (Ds.Tables("buku"))


    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub pencarianBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tabelBuku()
    End Sub
End Class