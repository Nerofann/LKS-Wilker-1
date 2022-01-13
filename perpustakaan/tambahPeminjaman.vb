Imports System.Data.SqlClient

Public Class tambahPeminjaman
    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand
    Public Shared stokBuku As Integer

    Sub tambahPeminjaman()
        Call login.koneksi()
        Da = New SqlDataAdapter("select petugas.id_petugas, anggota.nama_lengkap , anggota.nik , anggota.alamat , anggota.tgl_daftar, peminjaman.id_pinjam  from petugas join anggota on(petugas.id_petugas=anggota.id_anggota)join peminjaman on(petugas .id_petugas=peminjaman .id_petugas )", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tambahPinjaman")
        DataGridView1.DataSource = (Ds.Tables("tambahPinjaman"))

    End Sub

    Sub namaAnggota()
        Cmd = New SqlCommand("select * from anggota", login.Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        While Rd.Read
            ComboBox1.Items.Add(Rd("nama_lengkap"))

        End While

    End Sub

    Sub pertama()
        Call login.koneksi()
        Cmd = New SqlCommand("insert into peminjaman values('" & TextBox1.Text & "', )")


    End Sub

    Sub cariIdPetugas()
        Call login.koneksi()
        Cmd = New SqlCommand("select * from petugas", login.Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        While Rd.Read
            ComboBox2.Items.Add(Rd("nama_petugas").ToString)


        End While

    End Sub

    Sub finalIdPetugas()
        Rd.Close()
        Call login.koneksi()
        TextBox7.Text = login.TextBox1.Text
        Cmd = New SqlCommand("select * from petugas where nama_petugas='" & ComboBox2.Text & "' ", login.Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            TextBox8.Text = Rd("id_petugas").ToString
            Rd.Close()

        Else
            MessageBox.Show("nama Petugas tidak valid")
            Rd.Close()

        End If
    End Sub

    Private Sub tambahPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tambahPeminjaman()
        Call namaAnggota()
        Call cariIdPetugas()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Call finalIdPetugas()
        If TextBox7.Text <> "" And TextBox8.Text <> "" Then
            Call login.koneksi()
            Cmd = New SqlCommand("insert into peminjaman values('" & TextBox1.Text & "', '" & TextBox8.Text & "')", login.Conn)
            Cmd.ExecuteNonQuery()

            dataPinjaman.Show()
            Call dataPinjaman.dataPinjaman()

            MsgBox("Lanjutkan", vbOKOnly)

            If MsgBoxResult.Ok Then
                Call login.koneksi()
                Cmd = New SqlCommand("select * from peminjaman where id_anggota='" & TextBox1.Text & "' and id_petugas='" & TextBox8.Text & "' ", login.Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    TextBox9.Text = Rd("id_pinjam").ToString
                    Rd.Close()

                    Call login.koneksi()
                    Cmd = New SqlCommand("insert into peminjaman_buku values('" & TextBox2.Text & "', '" & TextBox9.Text & "', cast('" & DateTimePicker1.Text & "' as datetime) , cast('" & DateTimePicker2.Text & "' as datetime), cast('" & DateTimePicker2.Text & "' as datetime),'0'  )", login.Conn)
                    Cmd.ExecuteNonQuery()
                    MsgBox("stok buku berkurang", vbOKOnly)
                    If MsgBoxResult.Ok Then
                        Call login.koneksi()

                        Cmd = New SqlCommand("select * from buku where kode_buku='" & TextBox2.Text & "' ", login.Conn)
                        Rd = Cmd.ExecuteReader
                        Rd.Read()

                        If Rd.HasRows Then
                            stokBuku = Rd("stok")
                            stokBuku = stokBuku - 1

                            TextBox12.Text = stokBuku
                            Rd.Close()

                            Call login.koneksi()
                            Cmd = New SqlCommand("update buku set stok='" & TextBox12.Text & "' where kode_buku='" & TextBox2.Text & "' ", login.Conn)
                            Cmd.ExecuteNonQuery()


                        End If


                    End If



                End If

            End If



        Else
            MessageBox.Show("isi data dengan benar")


            End If




    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Rd.Close()
        Button4.Hide()
        Button2.Enabled = False
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call login.koneksi()
        Cmd = New SqlCommand("Select * from buku where kode_buku='" & TextBox2.Text & "' ", login.Conn)
                        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            TextBox3.Text = Rd("judul").ToString
            TextBox4.Text = Rd("penerbit").ToString
            TextBox5.Text = Rd("penulis").ToString
            TextBox6.Text = Rd("id_kat").ToString
            Rd.Close()

        Else
            MessageBox.Show("kode buku belm terdaftar")


        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button4.Show()
        Button2.Enabled = True
        ComboBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call login.koneksi()
        Cmd = New SqlCommand("Select * from anggota where nama_lengkap='" & ComboBox1.Text & "' ", login.Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Rd.HasRows Then
            TextBox1.Text = Rd("id_anggota").ToString
            MessageBox.Show("Anggota dikenali")
            Rd.Close()

        Else
            MessageBox.Show("nama anggota tidak terdaftar")
            Rd.Close()

        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call finalIdPetugas()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call login.koneksi()
        Cmd = New SqlCommand("select * from peminjaman_buku where id_pinjam='" & TextBox11.Text & "' ", login.Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Rd.HasRows Then
            Rd.Close()
            Call login.koneksi()
            Cmd = New SqlCommand("delete from peminjaman_buku where id_pinjam='" & TextBox11.Text & "' ", login.Conn)
            Cmd.ExecuteNonQuery()

            Call login.koneksi()
            Cmd = New SqlCommand("delete from peminjaman where id_pinjam='" & TextBox11.Text & "' ", login.Conn)
            Cmd.ExecuteNonQuery()
            Call tambahPeminjaman()
            MessageBox.Show("data Terhapus")
            stokBuku = stokBuku + 1
            TextBox12.Text = stokBuku
            Cmd = New SqlCommand("select * from buku where stok='" & TextBox12.Text & "' ", login.Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Dim tambahStok As Integer
                TextBox12.Text = Rd("stok").ToString
                tambahStok = Rd("stok").ToString
                Rd.Close()
                Cmd = New SqlCommand("update buku set stok='" & TextBox12.Text & "' where stok ='" & tambahStok & "' ", login.Conn)
                TextBox11.Text = ""
                Cmd.ExecuteNonQuery()

            Else
                TextBox11.Text = ""
                MessageBox.Show("stok buku tidak ditemukan")

            End If


        Else
            Rd.Close()
            Call login.koneksi()
            Cmd = New SqlCommand("delete from peminjaman where id_pinjam='" & TextBox11.Text & "' ", login.Conn)
            Cmd.ExecuteNonQuery()
            Call tambahPeminjaman()
            MessageBox.Show("data Terhapus")

        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox11.Text = DataGridView1.Item(5, i).Value

    End Sub
End Class