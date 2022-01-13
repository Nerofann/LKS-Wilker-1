Imports System.Data.SqlClient
Public Class dataPinjaman
    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand

    Sub dataPinjaman()
        Call login.koneksi()
        Da = New SqlDataAdapter("select peminjaman.id_pinjam, anggota.nama_lengkap , petugas.nama_petugas, peminjaman_buku .tgl_pinjam from  peminjaman join anggota on(peminjaman.id_anggota = anggota.id_anggota )join petugas on(peminjaman .id_petugas = petugas.id_petugas ) join peminjaman_buku on (peminjaman .id_pinjam = peminjaman_buku .id_pinjam )order by id_pinjam", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "dataPinjaman")
        DataGridView1.DataSource = (Ds.Tables("dataPinjaman"))

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        detailPeminjaman.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tambahPeminjaman.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub dataPinjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call dataPinjaman()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(1, i).Value

    End Sub
End Class