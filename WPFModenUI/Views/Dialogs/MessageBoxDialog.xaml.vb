Imports Wpf.Ui.Controls

Namespace WPFModenUI
    Public Class MessageBoxDialog
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MessageBoxDialogButtonYes_Click()
            Me.Close()
            Application.Current.Shutdown()
        End Sub

        Private Sub MessageBoxDialogButtonNo_Click()
            Me.Close()
        End Sub
    End Class
End Namespace