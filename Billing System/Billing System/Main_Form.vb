Public Class Main_Form
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)

        Login.Show()
        Me.Close()

    End Sub


    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()

    End Sub

    Private Sub pslots_btn_Click(sender As Object, e As EventArgs) Handles pslots_btn.Click
        pslots_btn.ForeColor = Color.FromArgb(174, 99, 169)
        pslots_btn.FocusedColor = Color.DimGray
        Guna2Button2.ForeColor = Color.FromArgb(80, 58, 74)
        Guna2Button1.ForeColor = Color.FromArgb(80, 58, 74)
        switchPanel(Dashboard)
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        switchPanel(Vehicle_category)
        pslots_btn.ForeColor = Color.FromArgb(80, 58, 74)
        Guna2Button2.FocusedColor = Color.DimGray
        Guna2Button2.ForeColor = Color.FromArgb(174, 99, 169)
        Guna2Button1.ForeColor = Color.FromArgb(80, 58, 74)
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        pslots_btn.ForeColor = Color.FromArgb(80, 58, 74)
        Guna2Button2.ForeColor = Color.FromArgb(80, 58, 74)
        Guna2Button1.ForeColor = Color.FromArgb(174, 99, 169)
        Guna2Button1.FocusedColor = Color.DimGray
        switchPanel(Manage_reports)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim Confirm As DialogResult = MessageBox.Show("Are you sure you want to logout ?", "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Confirm = DialogResult.Yes Then
            ParkNow.Show()
            Me.Close()
        End If
    End Sub


    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        switchPanel(Dashboard)
        pslots_btn.ForeColor = Color.FromArgb(174, 99, 169)
        pslots_btn.FocusedColor = Color.DimGray
        Guna2Button2.ForeColor = Color.FromArgb(80, 58, 74)
        Guna2Button1.ForeColor = Color.FromArgb(80, 58, 74)

    End Sub


End Class