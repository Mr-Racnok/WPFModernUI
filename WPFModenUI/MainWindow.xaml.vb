Imports System.Media
Imports Wpf.Ui.Controls
Imports WPFModenUI.WPFModenUI

Class MainWindow

    Public Sub New()
        InitializeComponent()
        With SideNavigation
            .IsPaneOpen = False
            .Visibility = Visibility.Visible
        End With
        'goto_Login()
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

    Sub goto_Login()
        FrameContent.Navigate(New Uri("Login.xaml", UriKind.Relative))
    End Sub

    Private Sub MessageBoxDialog_Open(sender As Object, e As RoutedEventArgs)
        Dim dialog As New MessageBoxDialog()
        With dialog
            .Width = 70
            .MessageBoxDialogTitle.Text = "Warning"
            .MessageBoxDialogText.Text = "Seluruh data yang belum disimpan akan hilang."
            .MessageBoxDialogButtonYes.Appearance = ControlAppearance.Danger
            .MessageBoxDialogButtonYes.Foreground = New BrushConverter().ConvertFromString("#ffffff")
        End With
        dialog.ShowDialog()
    End Sub

End Class
