Imports System.Data.SqlClient

Public Class detailPeminjaman
    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand

    Sub detailPinjaman()
        Call login.koneksi()
        Da = New SqlDataAdapter("select peminjaman.id_pinjam, anggota.nama_lengkap , petugas.nama_petugas, peminjaman_buku .tgl_pinjam , peminjaman_buku .tgl_kembali  from  peminjaman join anggota on(peminjaman.id_anggota = anggota.id_anggota )join petugas on(peminjaman .id_petugas = petugas.id_petugas ) join peminjaman_buku on (peminjaman .id_pinjam = peminjaman_buku .id_pinjam )where anggota.nama_lengkap = '" & dataPinjaman.TextBox1.Text & "' ", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detailPinjaman")
        DataGridView1.DataSource = (Ds.Tables("detailPinjaman"))

    End Sub
    Private Sub detailPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call detailPinjaman()

    End Sub
End Class