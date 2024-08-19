Imports Wpf.Ui.Controls

Namespace WPFModenUI
    Public Class CreateUserPage
        Dim Dec As New PublicDeclarations()

        Public Sub New()
            InitializeComponent()
            With Role.Items
                .Add("Admin")
                .Add("User")
                .Add("Moderator")
            End With
        End Sub

        Private Sub Border_MouseDown(sender As Object, e As MouseButtonEventArgs)
            If e.LeftButton = MouseButtonState.Pressed Then
                Me.DragMove()
            End If
        End Sub

        Private Sub Border_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
            If e.ClickCount = 2 Then
                If Me.WindowState = WindowState.Maximized Then
                    Me.WindowState = WindowState.Normal
                Else
                    Me.WindowState = WindowState.Maximized
                End If
            End If
        End Sub

        Private Sub MessageBoxDialog_Open(sender As Object, e As RoutedEventArgs)
            Dim dialog As New MessageBoxDialog2()
            With dialog
                .Width = 70
                .MessageBoxDialogTitle.Text = "Warning"
                .MessageBoxDialogText.Text = "Seluruh data yang belum disimpan akan hilang."
                .MessageBoxDialogButtonYes.Appearance = ControlAppearance.Danger
                .MessageBoxDialogButtonYes.Foreground = New BrushConverter().ConvertFromString("#ffffff")
            End With
            dialog.ShowDialog()

            Dim app = CType(Application.Current, Application)
            If app.ControllersWindowInstance Is Nothing Then
                app.ControllersWindowInstance = New ControllersWindow()
            End If
            If app.ControllersWindowInstance.ExitForm.Text = "True" Then
                Me.Close()
            End If
        End Sub

    End Class
End Namespace
