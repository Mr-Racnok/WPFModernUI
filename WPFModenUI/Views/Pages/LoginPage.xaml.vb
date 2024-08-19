Imports Wpf.Ui.Controls
Imports WPFModenUI.WPFModenUI
Imports WPFModenUI.PublicDeclarations
Imports System.Windows.Threading

Public Class LoginPage
    Dim Dec As New PublicDeclarations()

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
        Dim dialog As New MessageBoxDialog()
        With dialog
            .Width = 70
            .MessageBoxDialogTitle.Text = "Caution"
            .MessageBoxDialogText.Text = "Anda yakin ingin keluar ?"
            .MessageBoxDialogButtonYes.Appearance = ControlAppearance.Danger
            .MessageBoxDialogButtonYes.Foreground = New BrushConverter().ConvertFromString("#ffffff")
        End With
        dialog.ShowDialog()
    End Sub

    Private Sub CheckEmptyFields()
        ' Ambil elemen anak dari Border
        Dim border As Border = TryCast(Me.Content, Border)

        If border Is Nothing Then
            MsgBox("Content is not a Border")
            Exit Sub
        End If

        ' Ambil elemen anak dari Grid di dalam Border
        Dim grid As Grid = TryCast(border.Child, Grid)

        If grid Is Nothing Then
            MsgBox("Child of Border is not a Grid")
            Exit Sub
        End If

        ' Ambil elemen anak dari StackPanel di dalam Grid
        Dim stackPanel As StackPanel = Nothing
        For Each element As UIElement In grid.Children
            If TypeOf element Is StackPanel Then
                stackPanel = CType(element, StackPanel)
                Exit For
            End If
        Next

        If stackPanel Is Nothing Then
            MsgBox("Child of Grid is not a StackPanel")
            Exit Sub
        End If

        Dim dialog As New MessageBoxDialog()
        Dec.CanProceed = False

        ' Loop melalui semua elemen di dalam StackPanel
        For Each child As UIElement In stackPanel.Children
            If TypeOf child Is Control AndAlso CType(child, Control).Tag IsNot Nothing AndAlso CType(child, Control).Tag.ToString().Contains("_rq_") Then
                If TypeOf child Is Wpf.Ui.Controls.TextBox AndAlso String.IsNullOrWhiteSpace(CType(child, Wpf.Ui.Controls.TextBox).Text) Then
                    CType(child, Wpf.Ui.Controls.TextBox).Focus()
                    Dec.ToastNotificationTitle = "Caution"
                    Dec.ToastNotificationText = CType(child, Wpf.Ui.Controls.TextBox).Name & " harus diisi."
                    Dec.CanProceed = False
                    GoTo Akhiri
                ElseIf TypeOf child Is Wpf.Ui.Controls.PasswordBox AndAlso String.IsNullOrWhiteSpace(CType(child, Wpf.Ui.Controls.PasswordBox).Password) Then
                    CType(child, Wpf.Ui.Controls.PasswordBox).Focus()
                    Dec.ToastNotificationTitle = "Caution"
                    Dec.ToastNotificationText = CType(child, Wpf.Ui.Controls.PasswordBox).Name & " harus diisi."
                    Dec.CanProceed = False
                    GoTo Akhiri
                Else
                    Dec.CanProceed = True
                End If
            End If
        Next
        If Dec.CanProceed Then
            Dim mainWindow As New MainWindow()
            mainWindow.AppTitle.Text = "Ganti nama aplikasi" ' Membuat instance baru dari MainWindow
            mainWindow.Show() ' Menampilkan MainWindow
            Me.Close()
        End If
        Exit Sub
Akhiri:
        With Me.ToastNotification
            .Title = Dec.ToastNotificationTitle
            .Message = Dec.ToastNotificationText
            .IsOpen = True
            .Severity = Wpf.Ui.Controls.InfoBarSeverity.Warning
        End With

        ' Timer untuk menutup InfoBar setelah 3 detik
        Dim timer As New DispatcherTimer()
        AddHandler timer.Tick, Sub(s, args)
                                   Me.ToastNotification.IsOpen = False
                                   timer.Stop()
                               End Sub
        timer.Interval = TimeSpan.FromSeconds(3)
        timer.Start()
    End Sub

    Private Sub CreateNewUser_ClickLama()
        With Me.ToastNotification
            .Title = "Info"
            .Message = "Fitur belum tersedia."
            .IsOpen = True
            .Severity = Wpf.Ui.Controls.InfoBarSeverity.Informational
        End With

        ' Timer untuk menutup InfoBar setelah 3 detik
        Dim timer As New DispatcherTimer()
        AddHandler timer.Tick, Sub(s, args)
                                   Me.ToastNotification.IsOpen = False
                                   timer.Stop()
                               End Sub
        timer.Interval = TimeSpan.FromSeconds(3)
        timer.Start()
    End Sub

    Private Sub CreateNewUser_Click(sender As Object, e As RoutedEventArgs)
        Dim createUserPage As New CreateUserPage()

        createUserPage.ShowDialog()
    End Sub


End Class
