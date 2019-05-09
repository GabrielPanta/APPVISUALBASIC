Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conex As New MySqlConnection("
                                    data source=localhost;
                                    user id=root;
                                    password='';
                                    database=persona")
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim sql As String
    Dim comando As MySqlCommand

    Private Sub btnmostrardatos_Click(sender As Object, e As EventArgs) Handles btnmostrardatos.Click

        Call mostrardatos()

    End Sub

    Private Sub mostrardatos()
        Try
            sql = "select * from datos"
            da = New MySqlDataAdapter(sql, conex)
            dt = New DataTable
            da.Fill(dt)
            Datos.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Datos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos.RowEnter
        sql = Datos.Rows(e.RowIndex).Cells(0).Value.ToString
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Call guardardatos()
    End Sub

    Private Sub guardardatos()
        Dim r As Integer
        Try
            conex.Open()
            comando = New MySqlCommand("insert into datos values('" & txtcodigo.Text & "','" & txtnombre.Text & "','" & txtapellidos.Text & "')", conex)
            r = comando.ExecuteNonQuery()
            If r > 0 Then
                MsgBox("Registrado Correctamente")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        conex.Close()
    End Sub

End Class