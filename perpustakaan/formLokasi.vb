Imports System.Data.SqlClient

Public Class formLokasi

    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand
    Private Sub formLokasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call login.koneksi()
        Da = New SqlDataAdapter("select * from lokasi", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "lokasi")
        DataGridView1.DataSource = (Ds.Tables("lokasi"))


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button4.Show()
        Cmd = New SqlCommand("insert into lokasi values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')", login.Conn)
        Cmd.ExecuteNonQuery()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Hide()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True

    End Sub
End Class