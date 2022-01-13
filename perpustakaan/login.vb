Imports System.Data.SqlClient


Public Class login

    Public Shared Conn As SqlConnection
    Dim Da As SqlDataAdapter
    Dim Ds As DataSet
    Dim Rd As SqlDataReader
    Dim Cmd As SqlCommand
    Dim MyDb As String
    Dim salah As Integer


    Sub koneksi()
        MyDb = "data source=LAPTOP-LIQL7AGO; initial catalog=perpustakaan; integrated security=true;"
        Conn = New SqlConnection(MyDb)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

    End Sub

    'Sub captcha()
    'Dim nilai = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890"
    'Dim count = 0
    ' Rndm As New Random
    'hasil As String
    'Dim fff = ""

    'While count < 5
    'fff = Rndm.Next(0, nilai.Length)
    '  hasil = hasil + nilai
    ' count = count + 1

    ''End While
    'TextBox3.Text = hasil

    'End Sub


    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call captcha()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox3.Enabled = False
        Call koneksi()
        Cmd = New SqlCommand("select * from users where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "' ", Conn)
        Rd = Cmd.ExecuteReader()
        Rd.Read()

        If Rd.HasRows Then
            ' If Then


            If Rd("level").ToString = "admin" Then
                menuAdmin.Show()
                Rd.Close()
                Me.Hide()


            Else
                menuUsers.Show()
                Rd.Close()
                Me.Hide()
            End If

            'End If

        Else
            salah = salah + 1
            TextBox5.Text = salah
            MsgBox("Username dan Password belum terdaftar", vbOKOnly)
            If MsgBoxResult.Ok Then
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
            End If
        End If


    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End

    End Sub
End Class
