Imports MySql.Data.MySqlClient

Public Class ParkNow
    Private Sub ParkNow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2Button1.FillColor = ColorTranslator.FromHtml("#A269B3")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If IsDatabaseConnected() Then
            Login.Show()
            Me.Close()
        Else
            MsgBox("Error connecting to the database. Please check your database connection settings.")
        End If

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If IsDatabaseConnected() Then
            Customers_Mainform.Show()
            Me.Close()
        Else
            MsgBox("Error connecting to the database. Please check your database connection settings.")
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Credits.Show()
        Me.Close()
    End Sub
    Private Function IsDatabaseConnected() As Boolean
        Dim connectionString As String = "Server=localhost;user id=root;password=;database=parking_system;"
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Return True
            Catch ex As Exception
                MsgBox("Error connecting to the database. Please check your database connection settings.")
                Return False
            End Try
        End Using
    End Function
End Class