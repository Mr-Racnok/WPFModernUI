Imports Wpf.Ui.Controls

Namespace WPFModenUI
    Public Class MessageBoxDialog2
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MessageBoxDialogButtonYes_Click()
            Dim app = CType(Application.Current, Application)
            If app.ControllersWindowInstance Is Nothing Then
                app.ControllersWindowInstance = New ControllersWindow()
            End If
            app.ControllersWindowInstance.ExitForm.Text = "True"
            Me.Close()
        End Sub

        Private Sub MessageBoxDialogButtonNo_Click()
            Dim app = CType(Application.Current, Application)
            If app.ControllersWindowInstance Is Nothing Then
                app.ControllersWindowInstance = New ControllersWindow()
            End If
            app.ControllersWindowInstance.ExitForm.Text = "False"
            Me.Close()
        End Sub
    End Class
End Namespace
