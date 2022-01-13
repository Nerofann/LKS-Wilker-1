Imports System.Data.SqlClient

Public Class formKategori

    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand

    Sub tabelKategori()
        Call login.koneksi()
        Da = New SqlDataAdapter("select * from kategori", login.Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kategori")
        DataGridView1.DataSource = (Ds.Tables("kategori"))
    End Sub

    Private Sub formKategori_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tabelKategori()

        TextBox1.Enabled = False

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call login.koneksi()
        Cmd = New SqlCommand("insert into kategori values('" & TextBox1.Text & "') ", login.Conn)
        Cmd.ExecuteNonQuery()
        TextBox1.Enabled = False
        TextBox1.Text = ""

        Button4.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        TextBox1.Enabled = True
        Button4.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class