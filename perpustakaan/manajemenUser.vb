Imports System.Data.SqlClient

Public Class manajemenUser
    Dim Da As SqlDataAdapter
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand
    Dim Ds As DataSet


    Private Sub manajemenUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call login.koneksi()
        Da = New SqlDataAdapter("select * from buku where kode_buku=", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "buku")
        DataGridView1.DataSource = (Ds.Tables("buku"))


    End Sub
End Class