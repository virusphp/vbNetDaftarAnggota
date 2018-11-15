Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        TampilData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cmd = New SqlCommand
        Cmd.Connection = conn

        Query = "insert into anggota values('" & txtKD_ANGGOTA.Text & "', '" & txtNAMA_ANGGOTA.Text & "','" & txtALAMAT.Text & "')"
        Cmd.CommandText = Query
        Cmd.ExecuteNonQuery()
        TampilData()
        BersihkanForm()
        MsgBox("Berhasil di simpan!")
    End Sub

    Sub TampilData()
        DS = New DataSet

        Query = "select * from anggota"
        DA = New SqlDataAdapter(Query, conn)
        DA.Fill(DS)

        DataGridView1.DataSource = DS.Tables(0)
    End Sub

    Sub BersihkanForm()
        txtKD_ANGGOTA.Text = ""
        txtNAMA_ANGGOTA.Text = ""
        txtALAMAT.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cmd = New SqlCommand
        Cmd.Connection = conn

        Query = "update anggota set nama_anggota='" & txtNAMA_ANGGOTA.Text & "', alamat='" & txtALAMAT.Text & "' where kd_anggota='" & txtKD_ANGGOTA.Text & "'"
        Cmd.CommandText = Query
        Cmd.ExecuteNonQuery()
        TampilData()
        BersihkanForm()
        MsgBox("Berhasil di update!")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        txtKD_ANGGOTA.Text = DataGridView1.Item(0, i).Value
        txtNAMA_ANGGOTA.Text = DataGridView1.Item(1, i).Value
        txtALAMAT.Text = DataGridView1.Item(2, i).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Yakin ingin di hapus!!", vbInformation + vbYesNo) = vbYes Then
            Cmd = New SqlCommand
            Cmd.Connection = conn

            Query = "delete from anggota where kd_anggota='" & txtKD_ANGGOTA.Text & "'"
            Cmd.CommandText = Query
            Cmd.ExecuteNonQuery()
            TampilData()
            BersihkanForm()
            MsgBox("Berhasil di hapus!")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
    End Sub
End Class
