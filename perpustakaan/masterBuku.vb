Imports System.Data.SqlClient

Public Class masterBuku

    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand

    Sub tabelBuku()
        Da = New SqlDataAdapter("select * from buku", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "buku")
        DataGridView1.DataSource = (Ds.Tables("buku"))

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index



        TextBox2.Text = DataGridView1.Item(0, i).Value
        ComboBox2.Text = DataGridView1.Item(1, i).Value
        ComboBox1.Text = DataGridView1.Item(2, i).Value
        TextBox8.Text = DataGridView1.Item(3, i).Value
        TextBox3.Text = DataGridView1.Item(4, i).Value
        TextBox4.Text = DataGridView1.Item(5, i).Value
        TextBox5.Text = DataGridView1.Item(6, i).Value
        TextBox6.Text = DataGridView1.Item(7, i).Value
        TextBox7.Text = DataGridView1.Item(8, i).Value





    End Sub

    Private Sub masterBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tabelBuku()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Hide()

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button6.Enabled = False
        Button3.Enabled = False
        DataGridView1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button5.Show()
        Cmd = New SqlCommand("insert into buku values('" & TextBox2.Text & "', '" & ComboBox2.Text & "', '" & ComboBox1.Text & "','" & TextBox8.Text & "', '" & TextBox3.Text & "' , '" & TextBox4.Text & "',  '" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')", login.Conn)
        Cmd.ExecuteNonQuery()
        Call tabelBuku()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""

        MessageBox.Show("Tersimpan")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call login.koneksi()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Cmd = New SqlCommand("update buku set kode_lokasi='" & ComboBox2.Text & "', id_kat='" & ComboBox1.Text & "', judul='" & TextBox8.Text & "', penulis= '" & TextBox3.Text & "' , penerbit='" & TextBox4.Text & "', deskripsi='" & TextBox5.Text & "', harga='" & TextBox6.Text & "', stok='" & TextBox7.Text & "' where kode_buku ='" & TextBox2.Text & "' ", login.Conn)
        Cmd.ExecuteNonQuery()
        Call tabelBuku()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Hide()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button5.Enabled = False
        Button3.Enabled = False
        DataGridView1.Enabled = False


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call login.koneksi()
        Cmd = New SqlCommand("delete from buku where kode_buku='" & TextBox2.Text & "'", login.Conn)
        Cmd.ExecuteNonQuery()
        Call tabelBuku()

        MessageBox.Show("Terhapus")


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button6.Enabled = True
        Button6.Show()
        Button5.Show()
        Button5.Enabled = True
        Button3.Enabled = True
        DataGridView1.Enabled = True

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Call login.koneksi()
        Cmd = New SqlCommand("select * from buku where judul='" & TextBox1.Text & "' ", login.Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Rd.HasRows Then

            Rd.Close()
            Call tabelBuku()

        Else
            MessageBox.Show("Nama buku tidak ditemukan")
            Rd.Close()

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class