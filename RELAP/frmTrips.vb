﻿Public Class frmTrips
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.ColumnIndex = 1 Then
            DataGridView1.Rows(e.RowIndex).Cells(11).Value = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        End If
        If e.ColumnIndex = 4 Then
            DataGridView1.Rows(e.RowIndex).Cells(12).Value = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        End If
    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        DataGridView1.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
        cboTrip1.Items.Clear()
        cboTrip2.Items.Clear()
        For i = 1 To DataGridView1.RowCount - 1
            cboTrip1.Items.Add(i.ToString)
            cboTrip1.Items.Add("-" & i.ToString)
            cboTrip2.Items.Add(i.ToString)
            cboTrip2.Items.Add("-" & i.ToString)
        Next
    End Sub

    Private Sub frmTrips_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cboParameter1.DisplayMember = "Tag"
        cboParameter2.DisplayMember = "Tag"

        Try
            cboParameter1.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
            cboParameter2.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class