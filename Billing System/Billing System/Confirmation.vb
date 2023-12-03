Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class Confirmation
    Public Property SelectedSlot As String

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Dim customerName As String = Cname.Text
        Dim vehicleType2 As String = VehicleType.Text
        Dim parkingDetails2 As String = ParkingDetails.Text
        '   Dim plate As String = Guna2TextBox3.Text
        Dim textBox3Value As String = Guna2TextBox3.Text
        Dim textBox4Value As String = Guna2TextBox4.Text

        ' Create a connection string (modify it with your database details)
        Dim connectionString As String = "Server=localhost;user id=root;password=;database=parking_system;"

        ' Create a MySqlConnection
        Using connection As New MySqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create an INSERT query with parameters to avoid SQL injection
            Dim query As String = "INSERT INTO records_table (name,plate_num,vehicle_type,parking_slot,time_date,charge) VALUES (@param1, @param2, @param3, @param4,@param5,@param6)"

            ' Create a MySqlCommand
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to the command
                command.Parameters.AddWithValue("@param1", Cname.Text)
                command.Parameters.AddWithValue("@param2", plate_number.Text)

                command.Parameters.AddWithValue("@param3", VehicleType.Text)
                command.Parameters.AddWithValue("@param4", ParkingDetails.Text)
                command.Parameters.AddWithValue("@param6", Guna2TextBox3.Text)
                command.Parameters.AddWithValue("@param5", Guna2TextBox4.Text)





                ' Execute the query
                command.ExecuteNonQuery()

                ' Optionally display a success message
                MessageBox.Show("Data inserted successfully.")
            End Using
        End Using

        Dim lastId As Integer = GetLastInsertedId()
        VehicleType.Text = $"{lastId}"


    End Sub

    Private Function GetLastInsertedId() As Integer
        Dim connectionString As String = "Server=localhost;user id=root;password=;database=parking_system;"

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Assuming you just executed an INSERT query
            Dim query As String = "SELECT LAST_INSERT_ID()"

            Using command As New MySqlCommand(query, connection)
                Return Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using
    End Function


    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs)
        Customers_Mainform.Panel1.Visible = True
        Customers_Mainform.Panel2.Visible = False
        Customers_Mainform.Panel3.Visible = False

    End Sub

    Private Sub Confirmation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class