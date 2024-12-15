Public Class UserSession
    Private Shared _studentId As Integer

    Public Shared Property StudentId As Integer
        Get
            Return _studentId
        End Get
        Set(value As Integer)
            _studentId = value
        End Set
    End Property
End Class