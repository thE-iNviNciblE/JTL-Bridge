Public Class lvwSorter
    Public Class lvsorter(Of T As IComparable)
        Implements IComparer

        Private column As Integer
        Private tc As System.ComponentModel.TypeConverter

        Public Sub New(ByVal column As Integer)
            Me.column = column
            tc = System.ComponentModel.TypeDescriptor.GetConverter(GetType(T))
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As _
          Integer Implements System.Collections.IComparer.Compare
            Dim lvi1 As ListViewItem = CType(x, ListViewItem)
            Dim lvi2 As ListViewItem = CType(y, ListViewItem)
            Dim arg1 As T = tc.ConvertFromString(lvi1.SubItems(column).Text)
            Dim arg2 As T = tc.ConvertFromString(lvi2.SubItems(column).Text)
            If lvi1.ListView.Sorting = SortOrder.Ascending Then
                Return arg1.CompareTo(arg2)
            Else
                Return -arg1.CompareTo(arg2)
            End If
        End Function

    End Class
End Class
