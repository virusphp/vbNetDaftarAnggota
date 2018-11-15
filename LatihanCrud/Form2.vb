Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim LaporanPath As String = "D:\DOT NET\VB\LatihanCrud\LatihanCrud\CrystalReport1.rpt"
        Dim Laporan As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        DS = New DataSet

        Query = "select * from anggota where kd_anggota='" & Form1.txtKD_ANGGOTA.Text & "'"
        DA = New SqlDataAdapter(Query, conn)
        DA.Fill(DS)

        Laporan.Load(LaporanPath)
        Laporan.SetDataSource(DS.Tables(0))
        CrystalReportViewer1.ReportSource = Laporan
        CrystalReportViewer1.RefreshReport()

    End Sub
End Class