Imports System.Data.SqlClient
Module Module1
    Public conn As SqlConnection
    Public Query As String
    Public DA As SqlDataAdapter
    Public DS As DataSet
    Public Cmd As SqlCommand

    Sub koneksi()
        conn = New SqlConnection
        conn.ConnectionString = "data source=10.10.11.17;initial catalog=DBSIMRS;user=sa;password=Serverapi2018"

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                MsgBox("Koneksi Berhasil")
            End If
        Catch ex As Exception
            MsgBox("Koneksi Gagal")
        End Try
    End Sub
End Module
