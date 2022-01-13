Imports System.Data.SqlClient

Public Class formPengembalian
    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand
    Private Sub formPengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call login.koneksi()
        Da = New SqlDataAdapter("select buku.kode_buku, judul, peminjaman_buku.tgl_pinjam, peminjaman_buku.tgl_kembali, peminjaman_buku.denda from buku join peminjaman_buku on (buku.kode_buku = peminjaman_buku.kode_buku )", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "dataPengembalian")
        DataGridView1.DataSource = (Ds.Tables("dataPengembalian"))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class