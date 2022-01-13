Imports System.Data.SqlClient
Public Class masterAnggota
    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand

    Sub tabelAnggota()
        Da = New SqlDataAdapter("select * from anggota", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "anggota")
        DataGridView1.DataSource = (Ds.Tables("anggota"))

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox7.Visible = True
        DateTimePicker1.Visible = False

    End Sub

    Private Sub masterAnggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tabelAnggota()
        Button7.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cmd = New SqlCommand("select * from anggota where nama_lengkap='" & TextBox1.Text & "' ", login.Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Rd.Close()
            Call tabelAnggota()

        Else
            Rd.Close()
            MessageBox.Show("Anggota tidak terdaftar")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cmd = New SqlCommand("insert into anggota (id_anggota, nama_lengkap, nik, alamat, tgl_lahir, id_users) values('" & TextBox5.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', cast('" & DateTimePicker1.Text & "' as date), '" & TextBox6.Text & "') ", login.Conn)
        Cmd.ExecuteNonQuery()
        Call tabelAnggota()

        Button5.Show()
        Button6.Enabled = True
        Button3.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = False
        TextBox4.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox4.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Hide()
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox4.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        Button6.Enabled = False
        Button3.Enabled = False
        Button7.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Text = ""
        TextBox2.Enabled = False
        TextBox3.Text = ""
        TextBox3.Enabled = False
        TextBox4.Text = ""
        TextBox4.Enabled = False
        TextBox5.Text = ""
        TextBox5.Enabled = False
        TextBox6.Text = ""
        TextBox6.Enabled = False
        TextBox7.Text = ""
        TextBox7.Enabled = False
        Button5.Show()
        Button6.Show()
        Button5.Enabled = True
        Button6.Enabled = True
        Button3.Enabled = True

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Hide()
        Button5.Enabled = False
        Button3.Enabled = False
        TextBox4.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        Button7.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call login.koneksi()
        Cmd = New SqlCommand("delete from anggota where id_anggota = '" & TextBox5.Text & "'", login.Conn)
        Cmd.ExecuteNonQuery()
        Call tabelAnggota()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        TextBox5.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox3.Text = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(3, i).Value
        TextBox7.Text = DataGridView1.Item(4, i).Value
        TextBox6.Text = DataGridView1.Item(6, i).Value
    End Sub
End Class