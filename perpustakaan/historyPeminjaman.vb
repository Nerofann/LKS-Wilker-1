Imports System.Data.SqlClient

Public Class historyPeminjaman

    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand

    Sub tabelHistory()
        Da = New SqlDataAdapter("select buku.kode_buku, buku.judul, kategori.nama_kat , peminjaman_buku.tgl_pinjam , peminjaman_buku .tgl_kembali from buku join kategori on(buku.id_kat=kategori.id_kat) join peminjaman_buku on(buku.kode_buku = peminjaman_buku.kode_buku )", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pengembalian")
        DataGridView1.DataSource = (Ds.Tables("pengembalian"))

    End Sub
    Private Sub historyPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tabelHistory()
    End Sub

End Class