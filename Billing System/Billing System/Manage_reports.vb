

Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Manage_reports

    Private Function GetDataFromDatabase() As DataTable
        ' Retrieve the connection string from the configuration file
        Dim connectionString As String = "Server=localhost;user id=root;password=;database=parking_system;"

        ' Create MySqlConnection
        Using connection As New MySqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create SELECT query
            Dim query As String = "SELECT id, name, plate_num, vehicle_type, parking_slot, time_date, charge FROM records_table"

            ' Create MySqlCommand
            Using command As New MySqlCommand(query, connection)
                ' Create DataAdapter to retrieve data
                Using adapter As New MySqlDataAdapter(command)
                    ' Create DataTable to hold the data
                    Dim dataTable As New DataTable()

                    ' Fill the DataTable with data from the DataAdapter
                    adapter.Fill(dataTable)
                    For Each row As DataRow In dataTable.Rows
                        Dim dataGridViewRow As DataGridViewRow = New DataGridViewRow()
                        DataGridView1.Columns(6).Visible = False
                        dataGridViewRow.CreateCells(DataGridView1, row("id"), row("name"), row("plate_num"), row("vehicle_type"), row("parking_slot"), row("time_date"), row("charge"), row("charge"))

                        DataGridView1.Rows.Add(dataGridViewRow)

                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                        For Each row_user As DataGridViewRow In DataGridView1.Rows
                            For Each cell As DataGridViewCell In row_user.Cells
                                cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Next
                        Next
                    Next
                End Using
            End Using
        End Using
    End Function

    ' Subroutine to bind data to DataGridView
    Private Sub BindDataToDataGridView()
        ' Get data from the database
        Dim dataTable As DataTable = GetDataFromDatabase()

        ' Bind data to DataGridView
        DataGridView1.DataSource = dataTable
    End Sub

    ' Event handler for the form's Load event
    Private Sub YourForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load data into the DataGridView when the form is loaded
        BindDataToDataGridView()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
